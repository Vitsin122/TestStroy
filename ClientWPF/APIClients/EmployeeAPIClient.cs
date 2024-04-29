using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using ClientWPF.Model;

namespace ClientWPF.APIClients
{
    public static class EmployeeAPIClient
    {
        public static ObservableCollection<EmployeeGetDTO>? GetEmployees()
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5098/");

            HttpResponseMessage response = client.GetAsync("api/Employee/GetEmployees").Result;

            if (response.IsSuccessStatusCode)
            {
                var a = response.Content.ReadFromJsonAsync(typeof(ObservableCollection<EmployeeGetDTO>)).Result;

                return (ObservableCollection<EmployeeGetDTO>)a!;
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteEmployee(EmployeeGetDTO selectedEmployeeDTO)
        {
            using HttpClient client = new HttpClient();

            string url = "http://localhost:5098/api/Employee/DeleteEmployee";

            string jsonBody = JsonSerializer.Serialize(selectedEmployeeDTO);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = client.Send(request);

            return response.IsSuccessStatusCode;
        }
    }
}
