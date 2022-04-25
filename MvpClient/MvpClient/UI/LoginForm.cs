using System;
using System.Windows.Forms;
using MvpClient.Views;

namespace MvpClient.UI
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly ApplicationContext _context;

        public LoginForm(ApplicationContext context)
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
            try
            {
                Application.Run(_context);
            }
            catch (Exception)
            {
                base.Show();
            }
            
        }

    }
}
