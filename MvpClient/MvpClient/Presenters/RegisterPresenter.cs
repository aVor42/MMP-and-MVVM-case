using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MvpClient.Services;
using MvpClient.Views;
using MvpClient.Models;
using MvpClient.Common;

namespace MvpClient.Presenters
{
    internal class RegisterPresenter : BasePresenter<IRegisterView>
    {

        public RegisterPresenter(IApplicationController controller, IRegisterView view) :
            base(controller, view)
        {
            view.Login += Login;
            view.Register += Register;
        }

        private void Login()
        {
            Controller.Run<LoginPresenter>();
            View.Close();
        }

        private void Register()
        {
            try
            {
                var token = HttpRequestService.AuthOrRegister("https://localhost:44351/ToDo/Register", new Dictionary<string, string>
                {
                    ["login"] = View.Username,
                    ["password"] = View.Password
                });

                Controller.Run<NotesListPresenter, ModelContainer>(new ModelContainer { Authorization = token });
                View.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

    }
}
