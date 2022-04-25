using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MvpClient.Views;

namespace MvpClient.UI
{
    public partial class EditNoteForm : Form, IEditNoteView
    {
        public EditNoteForm()
        {
            InitializeComponent();
            buttonApplyChanges.Click += (sender, e) => ApplyChanges?.Invoke();
            buttonRemoveNote.Click += (sender, e) => RemoveNote?.Invoke();
        }

        public event Action ApplyChanges;
        public event Action RemoveNote;

        public string NoteName
        {
            get => textBoxNoteName.Text;
            set => textBoxNoteName.Text = value;
        }
        public int Order
        {
            get => (int)comboBoxOrder.SelectedItem;
            set => comboBoxOrder.SelectedItem = value;
        }
        public bool IsComplete
        {
            get => checkBoxIsComplete.Checked;
            set => checkBoxIsComplete.Checked = value;
        }

        public void SetOrderNumbers(IEnumerable<int> orderNumbers)
        {
            comboBoxOrder.Items.Clear();
            foreach(var number in orderNumbers)
                comboBoxOrder.Items.Add(number);
        }

        public new void Show()
        {
            ShowDialog();
        }
    }
}
