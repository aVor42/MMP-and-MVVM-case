using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvpClient.Common;
using MvpClient.Views;
using MvpClient.Models;
using MvpClient.Services;
using System.Windows.Forms;

namespace MvpClient.Presenters
{
    public class AddNotePresenter: BasePresenter<IAddNoteView, ModelContainer>
    {
        private string _token;
        private Note _note;

        public AddNotePresenter(IApplicationController controller, IAddNoteView view) :
            base(controller, view)
        {
            view.Add += Add;
            view.Cancel += Cancel;
        }

        public override void Run(ModelContainer container)
        {
            _token = container.Authorization;
            _note = container.Data as Note;
            View.Show();
        }

        private void Add()
        {
            try
            {
                HttpRequestService.Post("https://localhost:44351/ToDo/Notes/Add", _token, new Dictionary<string, string>
                {
                    ["name"] = View.NoteName,
                    ["day"] = _note.Day.ToString("yyyy-MM-dd")
                });

                View.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        private void Cancel()
        {
            View.Close();
        }
    }
}
