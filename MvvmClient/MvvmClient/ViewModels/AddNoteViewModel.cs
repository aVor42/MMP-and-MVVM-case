using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MvvmClient.Models;
using MvvmClient.Services;

namespace MvvmClient.ViewModels
{
    public class AddNoteViewModel: INotifyPropertyChanged
    {
        private string _token;
        private Note _note;
        private DelegateCommand _addCommand;

        public event EventHandler CloseRequest;
        public event PropertyChangedEventHandler PropertyChanged;

        public AddNoteViewModel(ModelContainer container)
        {
            _token = container.Token;
            _note = container.Data as Note;
        }

        public string NoteName
        {
            get => _note.Name;
            set => _note.Name = value;
        }

        private void Add(object obj)
        {
            try
            {
                HttpRequestService.Post("https://localhost:44351/ToDo/Notes/Add", _token, new Dictionary<string, string>
                {
                    ["name"] = _note.Name,
                    ["day"] = _note.Day.ToString("yyyy-MM-dd")
                });

                CloseRequest?.Invoke(this, new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new DelegateCommand(Add));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
