using CodingDojoSpeechService.Interfaces;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace CodingDojoSpeechService.Utils
{
    public class SpeechService : ISpeechService
    {
        //private string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        //private string speechRegion = "brazilsouth";

        //n sei se precisa do public, por ser static. Testar depois
        public async Task<string> AudioToText(SpeechConfig speechConfig, string uriAudio)
        {
            try
            {
                //speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                //reconhece a fala do dispositivo
                using var audioConfig = AudioConfig.FromWavFileInput(uriAudio);

                speechConfig.SpeechRecognitionLanguage = "pt-BR";


                using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                var result = await speechRecognizer.RecognizeOnceAsync();
                return result.Text;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        //public Task<IFormFile> TextToAudio(string text)
        //{


        //    try
        //    {

        //    }
        //    catch (Exception E)
        //    {

        //        return e.Message;
        //    }
        //}
    }
}
