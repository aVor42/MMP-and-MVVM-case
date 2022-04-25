using System.Windows.Forms;
using MvpClient.Common;
using MvpClient.Views;
using MvpClient.UI;
using MvpClient.Presenters;
using System.Threading;
using System;

namespace MvpClient
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapder())
                .RegisterView<INotesListView, NotesListForm>()
                .RegisterView<ILoginView, LoginForm>()
                .RegisterView<IRegisterView, RegisterForm>()
                .RegisterView<IAddNoteView, AddNoteForm>()
                .RegisterView<IEditNoteView, EditNoteForm>()
                .RegisterInstance(new ApplicationContext());

            var thread = new Thread(new ThreadStart(() =>
            {
                controller.Run<LoginPresenter>();
            }));
            thread.Start();
            
            //Console.ReadKey();

        }
    }
}