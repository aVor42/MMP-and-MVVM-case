using System;

namespace MvpClient.Views
{
    public interface ILoginView: IView
    {
        string Username { get; set; }
        string Password { get; set; }
        event Action Login;
        event Action Register;
    }
}
