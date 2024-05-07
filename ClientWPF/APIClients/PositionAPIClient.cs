using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientWPF.Model;

namespace ClientWPF.APIClients
{
    public static class PositionAPIClient
    {
        public static ObservableCollection<Position>? GetPositions()
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5098/");

            HttpResponseMessage response = client.GetAsync("api/Position/GetPositions").Result;

            if (response.IsSuccessStatusCode)
            {
                var a = response.Content.ReadFromJsonAsync(typeof(ObservableCollection<Position>)).Result;

                return (ObservableCollection<Position>)a!;
            }
            else
            {
                return null;
            }
        }
    }
}
