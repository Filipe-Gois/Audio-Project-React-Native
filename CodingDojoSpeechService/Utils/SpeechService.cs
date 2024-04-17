using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace CodingDojoSpeechService.Utils
{
    public class SpeechService
    {
        private string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        private string speechRegion = "brazilsouth";

        //n sei se precisa do public, por ser static. Testar depois
        public async Task<string> AudioToText(SpeechConfig speechConfig)
        {
            try
            {
                //speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                //reconhece a fala do dispositivo
                using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();


                using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                var result = await speechRecognizer.RecognizeOnceAsync();
                return result.Text.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
