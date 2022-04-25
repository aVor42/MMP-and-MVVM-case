using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvpClient.Views;

namespace MvpClient.UI
{
    public partial class RegisterForm : Form, IRegisterView
    {
        private readonly ApplicationContext _context;

        public RegisterForm(ApplicationContext context)
        {
            InitializeComponent();
            _context = context;

            buttonLogin.Click += (sender, e) => Login?.Invoke();
            buttonRegister.Click += (sender, e) => Register?.Invoke();
        }

        public event Action Login;
        public event Action Register;

        public string Username
        {
            get => textBoxLogin.Text;
            set => textBoxLogin.Text = value;
        }
        public string Password
        {
            get => textBoxPassword.Text;
            set => textBoxPassword.Text = value;
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

    }
}
