using InternetTaxi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace InternetTaxi.Services.Trips
{
    public class StartTripsService : IStartTripsService
    {
        private string Url = "http://localhost:19509/api/StartTrip";
        private string WUrl = "http://localhost:19509/api/Weather";
        private HttpClient _client;
        public StartTripsService()
        {
            _client = new HttpClient();
        }
        public InternetTaxiAPI.Commons.Models.TripModel StartTrip(TripModel model)
        {
            model.Price = 10000;
            var weatherres = _client.GetStringAsync(WUrl+"/"+model.City).Result;
            int temp = JsonConvert.DeserializeObject<int>(weatherres);

            var passengerres = _client.GetStringAsync(Url + "/" + model.PassengerId).Result;
            int passengerTrips = JsonConvert.DeserializeObject<int>(passengerres);
            if (temp < 20)
            {
                model.Price += 5000;
            }
            if (passengerTrips > 5)
            {
                model.Price -= 2000;
            }
            string JsonTrip = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(JsonTrip, Encoding.UTF8, "application/json");
            var res =  _client.PostAsync(Url, content).Result;
            string res2 = res.Content.ReadAsStringAsync().Result;
            var json = JsonConvert.DeserializeObject<InternetTaxiAPI.Commons.Models.TripModel>(res2);
            return json;
        }
    }
}
