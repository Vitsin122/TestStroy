using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public static bool SaveEmployee(Employer toSaveEmployer)
        {
            using HttpClient client = new HttpClient();

            string url = "http://localhost:5098/api/Employee/PostEmployee";

            string jsonBody = JsonSerializer.Serialize(toSaveEmployer);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = client.Send(request);

            return response.IsSuccessStatusCode;
        }

        public static bool EditEmployee(Employer toEditEmployer)
        {
            using HttpClient client = new HttpClient();

            string url = "http://localhost:5098/api/Employee/PutEmployee";

            string jsonBody = JsonSerializer.Serialize(toEditEmployer);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = client.Send(request);

            return response.IsSuccessStatusCode;
        }

        public static Employer? GetEmployee(EmployeeGetDTO currentEmployee)
        {
            using var client = new HttpClient();


            var url = $"http://localhost:5098/api/Employee/GetEmployee?SurName={currentEmployee.SurName}&FirstName={currentEmployee.FirstName}&PositionName={currentEmployee.PositionName}&IsActive={currentEmployee.IsActive}";

            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseBody = response.Content.ReadFromJsonAsync(typeof(Employer)).Result;

                return (Employer)responseBody!;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
