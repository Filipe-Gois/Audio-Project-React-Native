using CodingDojoSpeechService.Domains;
using CodingDojoSpeechService.Interfaces;
using CodingDojoSpeechService.Utils;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using WebAPI.Utils.BlobStorage;

using System.Threading.Tasks;

namespace CodingDojoSpeechService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechServiceController : ControllerBase
    {


        private readonly ISpeechService _speechService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="audio"></param>
        /// <returns></returns>

        public SpeechServiceController()
        {
            _speechService = new SpeechService();
        }
        /// <summary>
        /// Cadastra o audio no blob e retorna o texto do audio
        /// </summary>
        /// <param name="audio"></param>
        /// <returns></returns>




        static string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        static string speechRegion = "brazilsouth";

        [HttpPost("text-to-audio")]
        public async Task<IActionResult> TextToAudio([FromBody] string text)
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                speechConfig.SpeechSynthesisVoiceName = "pt-BR-AntonioNeural";

                using (var audioConfig = AudioConfig.FromWavFileOutput("output.wav"))
                using (var speech = new SpeechSynthesizer(speechConfig, audioConfig))
                {
                    var result = await speech.SpeakTextAsync(text);
                    return File(System.IO.File.ReadAllBytes("output.wav"), "audio/wav", "output.wav");

                }


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
