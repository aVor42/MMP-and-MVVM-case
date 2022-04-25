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
using System.Windows.Shapes;
using MvvmClient.Models;
using MvvmClient.ViewModels;

namespace MvvmClient
{
    /// <summary>
    /// Логика взаимодействия для EditNoteView.xaml
    /// </summary>
    public partial class EditNoteView : Window
    {
        public EditNoteView(ModelContainer container)
        {
            InitializeComponent();
            var vm = new EditNoteViewModel(container);
            DataContext = vm;
            vm.CloseRequest += (sender, e) => this.Close();
        }
    }
}
