using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MvpClient.Views;
using MvpClient.Models;

namespace MvpClient.UI
{
    public partial class NotesListForm : Form, INotesListView
    {
        private readonly ApplicationContext _context;

        public NotesListForm(ApplicationContext context)
        {
            InitializeComponent();
            _context = context;

            calendar.DateChanged += (sender, e) => ChangeDate?.Invoke(e);
            buttonLogout.Click += (sender, e) => Logout?.Invoke();
            buttonNewNote.Click += (sender, e) => AddNote?.Invoke();
            listBoxNotes.DoubleClick += (sender, e) => EditNote?.Invoke();
        }

        public event Action Logout;
        public event Action AddNote;
        public event Action EditNote;
        public event Action<DateRangeEventArgs> ChangeDate;

        public ListBox.ObjectCollection Notes { 
            get => listBoxNotes.Items;
        }
        public DateTime Day
        {
            get => calendar.SelectionStart;
        }
        public Note SelectedNote
        {
            get => listBoxNotes.SelectedItem as Note;
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }
    }
}
