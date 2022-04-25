using System;
using System.Windows.Forms;
using MvpClient.Views;

namespace MvpClient.UI
{
    public partial class AddNoteForm : Form, IAddNoteView
    {
        private readonly ApplicationContext _context;

        public AddNoteForm(ApplicationContext context)
        {
            InitializeComponent();
            _context = context;

            buttonCencel.Click += (sender, e) => Cancel?.Invoke();
            buttonAdd.Click += (sender, e) => Add?.Invoke();

        }

        public event Action Cancel;
        public event Action Add;

        public string NoteName { get => textBoxNoteName.Text; }

        public new void Show()
        {
            ShowDialog();
        }

    }
}
