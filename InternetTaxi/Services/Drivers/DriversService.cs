using InternetTaxi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace InternetTaxi.Services.Drivers
{
    public class DriversService : IDriversService
    {
        private string Url = "http://localhost:19509/api/Driver";
        private HttpClient _client;
        public DriversService()
        {
            _client = new HttpClient();
        }
        public bool Create(DriverModel model)
        {
            string JsonDriver = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(JsonDriver, Encoding.UTF8, "application/json");
            var res = _client.PostAsync(Url, content).Result;
            return res.IsSuccessStatusCode;
        }
        public List<InternetTaxiAPI.Models.DriverModel> Read()
        {
            var res = _client.GetStringAsync(Url).Result;
            var drivers = JsonConvert.DeserializeObject<List<InternetTaxiAPI.Models.DriverModel>>(res);
            return drivers;
        }
        public bool Delete(long id)
        {
            var res = _client.DeleteAsync(Url+"/"+id).Result;
            return res.IsSuccessStatusCode;
        }
        
    }
}
