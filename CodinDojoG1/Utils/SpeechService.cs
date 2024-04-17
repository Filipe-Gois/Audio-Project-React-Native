using Microsoft.CognitiveServices.Speech;

namespace CodinDojoG1.Utils
{
    public class SpeechService
    {
        private static string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        private static string speechRegion = "brazilsouth";
        protected async Task<string> RecognizeAudioToText(Stream audio)
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                

                using var recognize = new SpeechRecognizer(speechConfig);

               

                //var result = await recognize.RecognizeOnceAsync();

                var reason = GetRecognitionResultReason(audio);


                return reason.ToString();




                //using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                //using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);


                //var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();

                //return speechRecognitionResult.ToString();
            }
            catch (Exception e)
            {

                return "erro";
            }

        }
    }
}
