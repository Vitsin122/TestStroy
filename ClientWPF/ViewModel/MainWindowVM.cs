using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientWPF.Commands;
using ClientWPF.Model;

namespace ClientWPF.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<EmployeeGetDTO> EmployeeList { get; set; } = new();

        private RelayCommand mainWindowLoad;

        public RelayCommand MainWindowLoad
        {
            get
            {
                EmployeeList = new ObservableCollection<EmployeeGetDTO>();

                return mainWindowLoad ??= new RelayCommand(obj =>
                {
                    using var client = new HttpClient();

                    client.BaseAddress = new Uri("http://localhost:5098/");

                    try
                    {
                        HttpResponseMessage response = client.GetAsync("api/Employee/GetEmployees").Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var a = response.Content.ReadFromJsonAsync(typeof(ObservableCollection<EmployeeGetDTO>)).Result;


                            //Я уверен, что можно было сделать в геттере коллекции вызов события INotifyPropertyChanged и
                            //Полностью заменить всю коллекцию присвоением одной в другую
                            //Но пока так
                            foreach (var emploteeDto in (ObservableCollection<EmployeeGetDTO>)a)
                            {
                                EmployeeList.Add(emploteeDto);
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.StatusCode.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        private RelayCommand? checkCommand;

        public RelayCommand CheckCommand
        {
            get
            {
                return checkCommand ??= new RelayCommand(obj =>
                {
                    var b = EmployeeList;
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
