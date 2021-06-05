using Judges.Data;
using Judges.Data.Dto;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Judges.Services
{
    public class EventService : IEventService
    {
        private readonly string _url = "http://localhost:9000";
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<EventDto[]> GetEventsForJudge()
        {
            var responseString = await _httpClient.GetStringAsync(_url + "/Events/GetAllEvents");

            var response = JsonConvert.DeserializeObject<EventResponseModel>(responseString);

            if (!response.Success)
            {
                throw new Exception("Упс!");
            }

            return response.Events;
        }
    }
}
