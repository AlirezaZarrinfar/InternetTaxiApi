using System.Net.Http;

namespace InternetTaxi.Services.Trips
{
    public class EndTripsService : IEndTripsService
    {
        private string Url = "http://localhost:19509/api/EndTrip";
        private HttpClient _client;
        public EndTripsService()
        {
            _client = new HttpClient();
        }
        public string EndTrip(long Id)
        {
            var res = _client.GetStringAsync(Url + "/" + Id).Result;
            return res;
        }
    }
}
