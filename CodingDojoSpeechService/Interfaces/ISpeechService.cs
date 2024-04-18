using Microsoft.CognitiveServices.Speech;

namespace CodingDojoSpeechService.Interfaces
{
    public interface ISpeechService
    {
        public Task<string> AudioToText(SpeechConfig speechConfig, string uriAudio);

        public Task<IFormFile> TextToAudio(string text);
    }
}
