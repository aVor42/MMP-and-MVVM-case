using System;

namespace MvpClient.Views
{
    public interface IRegisterView: IView
    {
        string Username { get; set; }
        string Password { get; set; }
        event Action Login;
        event Action Register;
    }
}
