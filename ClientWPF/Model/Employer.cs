using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public class Employer : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id;
        private string firstName;
        private string lastName;
        private string surName;
        private DateTime? birthday;
        private short positionId;
        private Position position;
        private int salary;
        private bool isactive;

        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(Firstname))
                            error = "Имя не может быть пустым";
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(Lastname))
                            error = "Фамилия не может быть пустой";
                        break;
                    case "Salary":
                        if (Salary <= 0 && Salary is int)
                            error = "Зарплата должна быть больше нуля";
                        break;
                }
                return error;
            }
        }
        public string Error => null;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Firstname
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Surname
        {
            get => surName;
            set
            {
                surName = value;
                OnPropertyChanged("Surname");
            }
        }

        public string? Lastname
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("Lastname");
            }
        }

        public DateTime? Birthday
        {
            get => birthday;
            set
            {
                birthday = DateTime.SpecifyKind((DateTime)value!, DateTimeKind.Utc);
                OnPropertyChanged("Birthday");
            }
        }

        public short PositionId
        {
            get => positionId;
            set
            {
                positionId = value;
                OnPropertyChanged("PositionId");
            }
        }

        public Position? Position
        {
            get => position;
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public int Salary
        {
            get => salary;
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public bool isActive
        {
            get => isactive;
            set
            {
                isactive = value;
                OnPropertyChanged("isActive");
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
