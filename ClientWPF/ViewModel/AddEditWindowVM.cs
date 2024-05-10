﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ClientWPF.APIClients;
using ClientWPF.Commands;
using ClientWPF.Model;
using ClientWPF.View;

namespace ClientWPF.ViewModel
{
    public class AddEditWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> positionNames;

        public ObservableCollection<string> PositionNames
        {
            get => positionNames;
            set
            {
                positionNames = value;
                OnPropertyChanged("PositionNames");
            }
        }


        private Window addEditWindow;

        private OperationType type;


        private Employer? employer;
        public Employer? Employer
        {
            get => employer;
            set
            {
                employer = value;
                OnPropertyChanged("Employer");
            }
        }

        public AddEditWindowVM(Window window, OperationType type, Employer? employer = null)
        {
            PositionNames = new ObservableCollection<string>();

            addEditWindow = window;

            this.type = type;

            if (employer != null)
            {
                Employer = employer;
            }
            else
            {
                Employer = new Employer();
                Employer.Position = new Position();
            }
            
        }

        private RelayCommand? saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??= new RelayCommand(obj =>
                {
                    if (type == OperationType.Add)
                    {
                        EmployeeAPIClient.SaveEmployee(Employer);
                        addEditWindow.Close();
                    }
                    else
                    {
                        EmployeeAPIClient.EditEmployee(Employer);
                        addEditWindow.Close();
                    }
                }, (obj) => CanSave(obj));
            }
        }

        private RelayCommand? exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ??= new RelayCommand(obj =>
                {
                    addEditWindow.Close();
                });
            }
        }

        private RelayCommand? windowLoadedCommand;

        public RelayCommand WindowLoadedCommand
        {
            get
            {
                return windowLoadedCommand ??= new RelayCommand(obj =>
                {
                    var tempPositionNames = PositionAPIClient.GetPositions().Select(p => p.PositionName);

                    foreach (var VARIABLE in tempPositionNames)
                    {
                        PositionNames.Add(VARIABLE);
                    }
                });
            }
        }

        private RelayCommand? closedCommand;

        public RelayCommand ClosedCommand
        {
            get
            {
                return closedCommand ??= new RelayCommand(obj =>
                {
                    addEditWindow.Close();
                });
            }
        }

        public bool CanSave(object parameter)
        {
            return Employer["Firstname"] == String.Empty && Employer["Surname"] == String.Empty &&
                   Employer["Position"] == String.Empty;
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}