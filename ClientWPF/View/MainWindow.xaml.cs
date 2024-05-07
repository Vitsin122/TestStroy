using ClientWPF.ViewModel;
using System.Windows;


namespace ClientWPF.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM(this);
        }
    }
}