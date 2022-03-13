using InternetTaxi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxi.Services.Passengers
{
    public interface IPassengersService
    {
        public bool Create(PassengerModel model);
        public List<InternetTaxiAPI.Models.PassengerModel> Read();
        public bool Delete(long id);

    }
    public class PassengerService : IPassengersService
    {
        private string Url = "http://localhost:19509/api/Passenger";
        private HttpClient _client;
        public PassengerService()
        {
            _client = new HttpClient();
        }
        public bool Create(PassengerModel model)
        {
            string Jsonpass = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(Jsonpass, Encoding.UTF8, "application/json");
            var res = _client.PostAsync(Url, content).Result;
            return res.IsSuccessStatusCode;
        }
        public List<InternetTaxiAPI.Models.PassengerModel> Read()
        {
            var res = _client.GetStringAsync(Url).Result;
            var pass = JsonConvert.DeserializeObject<List<InternetTaxiAPI.Models.PassengerModel>>(res);
            return pass;
        }
        public bool Delete(long id)
        {
            var res = _client.DeleteAsync(Url + "/" + id).Result;
            return res.IsSuccessStatusCode;
        }
    }
}
