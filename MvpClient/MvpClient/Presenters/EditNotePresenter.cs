using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvpClient.Views;
using MvpClient.Models;
using MvpClient.Common;
using System.Text.Json;
using MvpClient.Services;
using System.Windows.Forms;

namespace MvpClient.Presenters
{
    public class EditNotePresenter: BasePresenter<IEditNoteView, ModelContainer>
    {
        private string _token;
        private Note _note;

        public EditNotePresenter(IApplicationController controller, IEditNoteView view):
            base(controller, view)
        {
            view.ApplyChanges += Apply;
            view.RemoveNote += RemoveNote;
        }

        public override void Run(ModelContainer container)
        {
            _token = container.Authorization;
            _note = container.Data as Note;
            FillView();
            View.Show();
        }

        private void FillView()
        {
            var jsonString = HttpRequestService.Get("https://localhost:44351/ToDo/Notes/Get", _token, new Dictionary<string, string>
            {
                ["day"] = _note.Day.ToString("yyyy-MM-dd")
            });
            var notesCount = JsonSerializer.Deserialize<List<object>>(jsonString).Count;

            View.SetOrderNumbers(Enumerable.Range(1, notesCount));

            View.NoteName = _note.Name;
            View.Order = _note.Order;
            View.IsComplete = _note.IsComplete;

        }

        private void Apply()
        {
            try
            {
                HttpRequestService.Put("https://localhost:44351/ToDo/Notes/Update", _token, new Dictionary<string, string>
                {
                    ["noteId"] = _note.Id.ToString(),
                    ["name"] = View.NoteName,
                    ["day"] = _note.Day.ToString("yyyy-MM-dd"),
                    ["order"] = View.Order.ToString(),
                    ["isComplete"] = View.IsComplete.ToString()
                });

                View.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        private void RemoveNote()
        {
            try
            {
                HttpRequestService.Delete("https://localhost:44351/ToDo/Notes/Delete", _token, new Dictionary<string, string>
                {
                    ["noteId"] = _note.Id.ToString()
                });

                View.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }
    }
}
