using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KataApiAspNet5.Katas
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class StationEntranceQuery
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
        public string destination { get; set; }
    }

    public class MetroInfo
    {
        private const string WmataURL = "https://api.wmata.com/Rail.svc/json/jStationEntrances";
      
        public string WmataStationInfo(StationEntranceQuery stationEntraceQuery)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(WmataURL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var wmataToken = "9f48e809625d454886f7c996ae55ac95";
            client.DefaultRequestHeaders.Add("api_key", wmataToken);
            
            var queryString = string.Format("?Lat={0}&Lon={1}&Radius={2}", 
                stationEntraceQuery.latitude, 
                stationEntraceQuery.longitude,
                stationEntraceQuery.radius);

            var response = client.GetAsync(queryString).Result;  
            if (response.IsSuccessStatusCode)
            {
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                var stationInfoResponse = response.Content.ReadAsStringAsync().Result;

                dynamic jsonObj = (JObject)JsonConvert.DeserializeObject(stationInfoResponse);

                //var closestStationInfo = jsonObj.Select(item => new 
                //{
                //    station = item["Value"]["NAME"]
                        
                //}); 

                return stationInfoResponse;
            }
            else
            {
                throw new Exception(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public class IEnumerable<ClosestStationInfo>
        {
            public string station { get; set; }
            public long stationLat { get; set; }
            public long stationLong { get; set; }
            public string[] departures { get; set; }
        }

    }
}
