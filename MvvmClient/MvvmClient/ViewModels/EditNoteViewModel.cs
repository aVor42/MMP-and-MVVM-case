using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using MvvmClient.Services;
using System.Collections.Generic;
using MvvmClient.Models;
using System.Text.Json;


namespace MvvmClient.ViewModels
{
    public class EditNoteViewModel: INotifyPropertyChanged
    {
        private DelegateCommand _deleteCommand;
        private DelegateCommand _editCommand;
        private Note _note;
        private string _token;
        

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CloseRequest;

        public EditNoteViewModel(ModelContainer container)
        {
            _token = container.Token;
            _note = container.Data as Note;
        }

        private int GetCountNotesOnDay(DateTime day)
        {
            var jsonString = HttpRequestService.Get("https://localhost:44351/ToDo/Notes/Get", _token, new Dictionary<string, string>
            {
                ["day"] = day.ToString("yyyy-MM-dd")
            });
            return JsonSerializer.Deserialize<List<object>>(jsonString).Count;
        }

        public ObservableCollection<int> Orders
        {
            get => new ObservableCollection<int>(Enumerable.Range(1, GetCountNotesOnDay(_note.Day)));
        }
        public string NoteName
        {
            get => _note.Name;
            set => _note.Name = value;
        }
        public int NoteOrder
        {
            get => _note.Order;
            set => _note.Order = value;
        }
        public bool IsComplete
        {
            get => _note.IsComplete;
            set => _note.IsComplete = value;
        }
        public DelegateCommand DeleteCommand
        {
            get
            {
                return _deleteCommand?? (_deleteCommand = new DelegateCommand(Delete));
            }
        }

        public void Delete(object obj)
        {
            try
            {
                HttpRequestService.Delete("https://localhost:44351/ToDo/Notes/Delete", _token, new Dictionary<string, string>
                {
                    ["noteId"] = _note.Id.ToString()
                });

                CloseRequest?.Invoke(this, new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
