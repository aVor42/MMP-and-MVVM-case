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
    public class NotesListViewModel: INotifyPropertyChanged
    {
        private string _token;
        private DelegateCommand _logoutCommand;
        private DelegateCommand _addCommand;
        private DateTime _day;
        private Note _selectedNote;

        public event EventHandler CloseRequest;
        public event PropertyChangedEventHandler PropertyChanged;

        public NotesListViewModel(ModelContainer container)
        {
            _token = container.Token;
        }

        private ObservableCollection<Note> GetNotes()
        {
            var jsonString = HttpRequestService.Get("https://localhost:44351/ToDo/Notes/Get", _token, new Dictionary<string, string>
            {
                ["day"] = Day.ToString("yyyy-MM-dd")
            });

            var notes = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString).
                Select(n => new Note
                {
                    Id = int.Parse(n["id"].ToString()),
                    Name = n["name"].ToString(),
                    IsComplete = bool.Parse(n["isComplete"].ToString()),
                    Day = DateTime.Parse(n["day"].ToString()),
                    Order = int.Parse(n["order"].ToString())
                });
            return new ObservableCollection<Note>(notes);
        }

        private void Logout(object obj)
        {
            try
            {
                HttpRequestService.Logout("https://localhost:44351/ToDo/Logout", _token);

                var mainWindow = new LoginView();
                mainWindow.Show();
                CloseRequest?.Invoke(this, new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        private void Add(object obj)
        {
            var note = new Note { Day = Day };
            var mainWindow = new AddNote(new ModelContainer { Token = _token, Data = note});
            mainWindow.ShowDialog();
            OnPropertyChanged("Notes");
        }

        public ObservableCollection<Note> Notes { get => GetNotes(); }
        public DateTime Day 
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertyChanged("Notes");
            } 
        }
        public Note SelectedNote 
        {
            get => _selectedNote; 
            set
            {
                _selectedNote = value;
                var mainWindow = new EditNoteView(new ModelContainer 
                { 
                    Token = _token, 
                    Data = _selectedNote
                });
                mainWindow.ShowDialog();
                OnPropertyChanged("Notes");
            }
        }
        public DelegateCommand LogoutCommand
        {
            get
            {
                return _logoutCommand ??
                  (_logoutCommand = new DelegateCommand(Logout));
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
