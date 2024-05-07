using System.Windows;
using ClientWPF.Model;
using ClientWPF.ViewModel;

namespace ClientWPF.View
{
    public partial class AddEditWindow : Window
    {
        public AddEditWindow(OperationType type, Employer? employeer = null)
        {
            InitializeComponent();
            DataContext = new AddEditWindowVM(this, type, employeer);
        }
    }
}
