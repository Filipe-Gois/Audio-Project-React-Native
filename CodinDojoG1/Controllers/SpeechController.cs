using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace CodinDojoG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SpeechController : ControllerBase
    {
        static string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        static string speechRegion = "brazilsouth";

        static string GetCancellationResultReason(SpeechRecognitionResult result)
        {
            var cancellation = CancellationDetails.FromResult(result);

            return cancellation.Reason.ToString();

        }

        static string GetRecognitionResultReason(SpeechRecognitionResult result) =>
            result.Reason switch
            {

                ResultReason.RecognizedSpeech => result.Text,
                ResultReason.NoMatch => $"Fala não reconhecida!",
                ResultReason.Canceled => result.Reason.ToString()
            };
        //=> GetCancellationResultReason(result) ---- colocar antes do "result.Reason.ToString()", caso apresente erro
        protected async Task<string> RecognizeAudioToText(SpeechRecognitionResult audio)
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

        [HttpPost("AudioToText")]
        public async Task<IActionResult> AudioToText([FromForm] SpeechRecognitionResult audio)
        {
            try
            {
                var text = await RecognizeAudioToText(audio);


                return StatusCode(201, text);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}


//switch (speechRecognitionResult.Reason)
//{
//    case ResultReason.RecognizedSpeech:
//        Console.WriteLine($"RECOGNIZED: Text={speechRecognitionResult.Text}");
//        break;
//    case ResultReason.NoMatch:
//        throw new Exception("NOMATCH: Speech could not be recognized.");
//    //break;
//    case ResultReason.Canceled:
//        var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
//        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

//        if (cancellation.Reason == CancellationReason.Error)
//        {
//            Console.WriteLine($"CANCELADA: ErrorCode={cancellation.ErrorCode}");
//            Console.WriteLine($"CANCELADA: ErrorDetails={cancellation.ErrorDetails}");
//            Console.WriteLine($"CANCELADA: Did you set the speech resource key and region values?");
//        }
//        break;
//}