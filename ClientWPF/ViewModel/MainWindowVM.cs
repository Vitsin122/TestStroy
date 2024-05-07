using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ClientWPF.APIClients;
using ClientWPF.Commands;
using ClientWPF.Model;
using ClientWPF.View;

namespace ClientWPF.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Window mainWindow;
        public MainWindowVM(Window mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public ObservableCollection<EmployeeGetDTO> EmployeeList { get; set; }

        private EmployeeGetDTO? selectedEmployeeDTO;
        public EmployeeGetDTO? SelectedEmployeeDTO
        {
            get => selectedEmployeeDTO;
            set
            {
                selectedEmployeeDTO = value;
                OnPropertyChanged("SelectedEmployeeDTO");
            }
        }
        

        private RelayCommand? mainWindowLoad;
        public RelayCommand MainWindowLoad
        {
            get
            {
                EmployeeList = new ObservableCollection<EmployeeGetDTO>();

                return mainWindowLoad ??= new RelayCommand(obj =>
                {
                    try
                    {
                        var employeesCollection = EmployeeAPIClient.GetEmployees();

                        foreach (var VARIABLE in employeesCollection)
                        {
                            EmployeeList.Add(VARIABLE);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }

        private RelayCommand? mainWindowClosed;

        public RelayCommand MainWindowClosed
        {
            get
            {
                return mainWindowClosed ??= new RelayCommand(obj =>
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                });
            }
        }

        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??= new RelayCommand( obj =>
                {
                    try
                    {
                        EmployeeAPIClient.DeleteEmployee(selectedEmployeeDTO);
                        EmployeeList.Remove(selectedEmployeeDTO);
                        selectedEmployeeDTO = null;
                        MessageBox.Show("Успешно");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                {
                    var AddWindow = new AddEditWindow(OperationType.Add);
                    AddWindow.Show();
                    mainWindow.Hide();
                });
            }
        }

        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??= new RelayCommand(obj =>
                {
                    Employer currentEmployer = EmployeeAPIClient.GetEmployee(selectedEmployeeDTO!);

                    var editWindow = new AddEditWindow(OperationType.Edit, currentEmployer); 
                    editWindow.Show();
                    mainWindow.Hide();
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
