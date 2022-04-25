using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Primitives;
using SuperApi.Models;

namespace SuperApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ToDoController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] string login, [FromForm] string password)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Login == login);

            if (currentUser == null)
                return BadRequest("Пользователя с таким логином не существует!");

            if (GetPasswordHash(password, currentUser.PasswordSalt) == currentUser.PasswordHash)
            {
                var userAuthorizations = _context.Authorizations.Where(a => a.User.Id == currentUser.Id);
                foreach (var authorizationRecord in userAuthorizations)
                    authorizationRecord.IsActive = false;

                var key = Guid.NewGuid();
                _context.Authorizations.Add(new Authorization
                {
                    Id = key,
                    User = currentUser,
                    Date = DateTime.Now,
                    IsActive = true
                });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest("Ошибка, обратитесь в службу поддержки!");
                }

                HttpContext.Response.Headers.Authorization = key.ToString();
            }
            else
            {
                return BadRequest("Неверный пароль!");
            }

            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] string login, [FromForm] string password)
        {
            if (_context.Users.FirstOrDefault(u => u.Login == login) != null)
                return BadRequest("Пользователь с таким логином уже существует");

            var salt = GenerateSalt();

            _context.Users.Add(new User
            {
                Login = login,
                PasswordSalt = salt,
                PasswordHash = GetPasswordHash(password, salt)
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return await Login(login, password);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            foreach (var auth in _context.Authorizations.Where(a => a.User.Id == currentUser.Id))
                auth.IsActive = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();
        }

        //----------------------------------------------------------------------------------------------

        [HttpGet("Notes/Get")]
        public IActionResult GetNotesOnDay(DateTime day)
        {

            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var notes = currentUser.Notes.Where(t => t.Day == day.Date).OrderBy(n => n.Order);

            var response = new List<Dictionary<string, object>>();
            foreach (var note in notes)
            {
                response.Add(new Dictionary<string, object>
                {
                    ["id"] = note.Id,
                    ["name"] = note.Name,
                    ["isComplete"] = note.IsComplete,
                    ["day"] = note.Day,
                    ["order"] = note.Order
                });
            }

            return Ok(response);
        }

        [HttpPost("Notes/Add")]
        public async Task<IActionResult> AddNote([FromForm] string name, [FromForm] DateTime day)
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var notesCount = currentUser.Notes.Where(t => t.Day == day.Date).Count();

            _context.Notes.Add(new Note
            {
                Name = name,
                Day = day,
                AddTime = DateTime.Now,
                IsComplete = false,
                User = currentUser,
                Order = notesCount + 1
            });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();
        }

        [HttpPut("Notes/SetComplete")]
        public async Task<IActionResult> SetComplete(int noteId, bool isComplete = true)
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var note = currentUser.Notes.
                FirstOrDefault(t =>
                t.Id == noteId &&
                t.User.Id == currentUser.Id);

            if (note == null)
                return BadRequest();

            note.IsComplete = isComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();
        }

        [HttpPut("Notes/Rename")]
        public async Task<IActionResult> RenameNote(int noteId, string newName)
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var note = currentUser.Notes.
                FirstOrDefault(t =>
                t.Id == noteId &&
                t.User.Id == currentUser.Id);

            if (note == null)
                return BadRequest();

            note.Name = newName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();
        }

        [HttpPut("Notes/Update")]
        public async Task<IActionResult> UpdateNote(int noteId, string name, int order, bool isComplete)
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var editedNote = _context.Notes.FirstOrDefault(n => 
            n.Id == noteId && 
            n.User.Id == currentUser.Id);

            if (editedNote == null)
                return BadRequest();

            var notesOnDay = currentUser.Notes.
                Where(n => n.Day == editedNote.Day.Date).
                OrderBy(n => n.Order);

            if(order > notesOnDay.Count())
                order = notesOnDay.Count();

            var oldOrder = editedNote.Order;
            
            foreach(var note in notesOnDay)
            {
                if (note.Order == oldOrder)
                {
                    note.Order = order;
                    note.Name = name;
                    note.IsComplete = isComplete;
                } 
                else if(note.Order >= order && note.Order <= oldOrder)
                {
                    note.Order++;
                }
                else if(note.Order < order && note.Order >= oldOrder)
                {
                    note.Order--;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();

        }

        [HttpDelete("Notes/Delete")]
        public async Task<IActionResult> Delete(int noteId)
        {
            var currentUser = GetUserFromToken(_httpContextAccessor.HttpContext?.Request);
            if (currentUser == null)
                return Unauthorized();

            var noteForDelete = _context.Notes.
                FirstOrDefault(n =>
                n.Id == noteId &&
                n.User.Id == currentUser.Id);

            if (noteForDelete == null)
                return BadRequest();

            _context.Notes.Remove(noteForDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка, обратитесь в службу поддержки!");
            }

            return Ok();
        }

        //----------------------------------------------------------------------------------------------

        private bool IsAuthorize(Guid? token)
        {
            if (!token.HasValue)
                return false;

            var authorization = _context.Authorizations.
                FirstOrDefault(a => a.Id == token.Value && a.IsActive);

            return authorization != null;
        }

        private Guid? GetToken(HttpRequest request)
        {
            if (request == null)
                return null;

            var stringToken = request.Headers.Authorization[0];
            Guid token;
            if (!Guid.TryParse(stringToken, out token))
                return null;

            return token;
        }

        private User GetUserFromToken(HttpRequest request)
        {
            var token = GetToken(request);
            if (!IsAuthorize(token))
                return null;

            var user = _context.Users.
                Include(u => u.Authorizations).
                Include(u => u.Notes).
                FirstOrDefault(u =>
                u.Authorizations.FirstOrDefault(a => a.Id == token.Value && a.IsActive) != null);

            return user;
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[16];
            using var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetNonZeroBytes(salt);
            return salt;
        }

        private string GetPasswordHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }

    }
}
