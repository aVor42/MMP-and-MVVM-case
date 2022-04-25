using System;

namespace MvpClient.Views
{
    public interface IAddNoteView: IView
    {
        event Action Cancel;
        event Action Add;
        string NoteName { get; }
    }
}
