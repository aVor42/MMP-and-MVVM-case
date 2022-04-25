using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MvpClient.Views;
using MvpClient.Models;
using MvpClient.Common;
using MvpClient.Services;

namespace MvpClient.Presenters
{
    public class LoginPresenter: BasePresenter<ILoginView>
    {

        public LoginPresenter(IApplicationController controller, ILoginView view):
            base(controller, view)
        {
            view.Register += Register;
            view.Login += Login;
        }

        private void Register()
        {
            Controller.Run<RegisterPresenter>();
            View.Close();
        }

        private void Login()
        {
            try
            {
                var token = HttpRequestService.AuthOrRegister("https://localhost:44351/ToDo/Login", new Dictionary<string, string>
                {
                    ["login"] = View.Username,
                    ["password"] = View.Password
                });

                Controller.Run<NotesListPresenter, ModelContainer>(new ModelContainer { Authorization = token });
                View.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }

        }

    }

}
