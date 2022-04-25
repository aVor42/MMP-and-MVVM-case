using System;
using System.Collections.Generic;

namespace MvpClient.Views
{
    public interface IEditNoteView: IView
    {
        event Action RemoveNote;
        event Action ApplyChanges;

        string NoteName { get; set; }
        int Order { get; set; }
        bool IsComplete { get; set; }

        void SetOrderNumbers(IEnumerable<int> orderNumbers);
    }
}
