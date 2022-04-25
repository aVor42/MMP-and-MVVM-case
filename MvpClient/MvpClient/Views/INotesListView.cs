using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvpClient.Models;

namespace MvpClient.Views
{
    public interface INotesListView: IView
    {
        ListBox.ObjectCollection Notes { get; }
        DateTime Day { get; }
        Note SelectedNote { get; }
        event Action Logout;
        event Action AddNote;
        event Action EditNote;
        event Action<DateRangeEventArgs> ChangeDate;
    }
}
