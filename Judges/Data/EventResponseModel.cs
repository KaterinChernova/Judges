using Judges.Data.Dto;

namespace Judges.Data
{
    public class EventResponseModel
    {
        public bool Success { get; set; }

        public EventDto[] Events { get; set; }
    }
}
