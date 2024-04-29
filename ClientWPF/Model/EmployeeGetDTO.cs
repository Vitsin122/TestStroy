using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public class EmployeeGetDTO : INotifyPropertyChanged
    {
        private string surName;
        private string firstName;
        private string positionName;
        private bool isAactive;

        public string SurName
        {
            get => surName;
            set
            {
                surName = value; 
                OnPropertyChanged("SurName");
            }
        }

        public string FirstName
        {
            get => firstName; 
            set 
            { 
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string PositionName
        {
            get => positionName;
            set
            {
                positionName = value;
                OnPropertyChanged("PositionName");
            }
        }

        public bool IsActive
        {
            get => isAactive;
            set
            {
                isAactive = value;
                OnPropertyChanged("IsActive");
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
