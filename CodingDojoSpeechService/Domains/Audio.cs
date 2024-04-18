using System.Text.Json.Serialization;

namespace CodingDojoSpeechService.Domains
{
    public class Audio
    {
        [JsonIgnore]
        public IFormFile? AudioFile { get; set; }
    }
}
