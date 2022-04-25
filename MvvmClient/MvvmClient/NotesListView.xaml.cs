using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvvmClient.ViewModels;
using MvvmClient.Models;

namespace MvvmClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class NotesListView : Window
    {
        public NotesListView(ModelContainer container)
        {
            InitializeComponent();
            var vm = new NotesListViewModel(container);
            DataContext = vm;
            vm.CloseRequest += (sender, e) => this.Close();
        }
    }
}
