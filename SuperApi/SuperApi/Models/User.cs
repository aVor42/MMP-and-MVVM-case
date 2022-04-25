namespace SuperApi.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Note> Notes { get; set; }
        public List<Authorization> Authorizations { get; set; }

    }
}
