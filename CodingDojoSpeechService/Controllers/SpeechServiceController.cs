using CodingDojoSpeechService.Utils;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;

namespace CodingDojoSpeechService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechServiceController : ControllerBase
    {
        private readonly string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        private readonly string speechRegion = "brazilsouth";

        private readonly SpeechService _speechService;

        public SpeechServiceController(SpeechService speechService)
        {
            _speechService = speechService;
        }
        public async Task<IActionResult> AudioToText()
        {
            try
            {
                //define o nome do container do blob storage
                var containerName = "audioscodingdojog1";

                var connectionString = "DefaultEndpointsProtocol=https;AccountName=audioscodingdojog1;AccountKey=JohUhAOEMe/PAXSPlRAwRLAp62Bt0CNjv2M5ZMp5ia4aa2v9kBVcpjTBsHsi9wnZ98MPZ0mvf7zG+AStEhWslQ==;EndpointSuffix=core.windows.net";


                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);



                //se der erro, atribuir esse await a uma variavel e passa-la no return
                return StatusCode(200, await _speechService.AudioToText(speechConfig));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
