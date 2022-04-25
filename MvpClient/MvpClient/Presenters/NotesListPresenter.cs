using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MvpClient.Views;
using MvpClient.Common;
using MvpClient.Models;
using MvpClient.Services;
using System.Text.Json;

namespace MvpClient.Presenters
{
    public class NotesListPresenter: BasePresenter<INotesListView, ModelContainer>
    {

        private string _token;

        public NotesListPresenter(IApplicationController controller, INotesListView view):
            base(controller, view)
        {
            view.ChangeDate += ChangeDate;
            view.Logout += Logout;
            view.AddNote += AddNote;
            view.EditNote += EditNote;
        }

        public override void Run(ModelContainer container)
        {
            _token = container.Authorization;
            SetNotes(DateTime.Now);
            View.Show();
        }

        private void AddNote()
        {
            var container = new ModelContainer
            {
                Authorization = _token,
                Data = new Note { Day = View.Day }
            };

            Controller.Run<AddNotePresenter, ModelContainer>(container);
            View.Notes.Clear();
            SetNotes(View.Day);
        }

        private void EditNote()
        {
            var container = new ModelContainer
            {
                Authorization = _token,
                Data = View.SelectedNote
            };
            Controller.Run<EditNotePresenter, ModelContainer>(container);
            View.Notes.Clear();
            SetNotes(View.Day);
        }

        private void ChangeDate(DateRangeEventArgs dateRange)
        {
            View.Notes.Clear();
            SetNotes(View.Day);
        }

        private void SetNotes(DateTime day)
        {
            var jsonString = HttpRequestService.Get("https://localhost:44351/ToDo/Notes/Get", _token, new Dictionary<string, string>
            {
                ["day"] = day.ToString("yyyy-MM-dd")
            });
            
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);

            foreach(var note in notes)
            {
                View.Notes.Add(new Note
                {
                    Id = int.Parse(note["id"].ToString()),
                    Name = note["name"].ToString(),
                    IsComplete = bool.Parse(note["isComplete"].ToString()),
                    Day = DateTime.Parse(note["day"].ToString()),
                    Order = int.Parse(note["order"].ToString())
                });
            }
        }

        private void Logout()
        {
            try
            {
                HttpRequestService.Logout("https://localhost:44351/ToDo/Logout", _token);

                Controller.Run<LoginPresenter>();
                View.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

    }
}
