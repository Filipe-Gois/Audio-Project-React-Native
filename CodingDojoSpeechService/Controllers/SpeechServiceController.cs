using CodingDojoSpeechService.Domains;
using CodingDojoSpeechService.Interfaces;
using CodingDojoSpeechService.Utils;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using WebAPI.Utils.BlobStorage;

namespace CodingDojoSpeechService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechServiceController : ControllerBase
    {
        private readonly string speechKey = "c081aeaf28e649e888c7f9b7150a6515";
        private readonly string speechRegion = "brazilsouth";

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
        [HttpPost("AudioToText")]
        public async Task<IActionResult> AudioToText([FromForm] Audio audio)
        {
            try
            {
                //define o nome do container do blob storage
                var containerName = "containercodingdojoaudiog1";

                var connectionString = "DefaultEndpointsProtocol=https;AccountName=audioscodingdojog1;AccountKey=JohUhAOEMe/PAXSPlRAwRLAp62Bt0CNjv2M5ZMp5ia4aa2v9kBVcpjTBsHsi9wnZ98MPZ0mvf7zG+AStEhWslQ==;EndpointSuffix=core.windows.net";



                //armazena a uri do audio upado no blob storage
                var uriAudioBlob = await AzureBlobStorageHelper.UploadAudioBlobAsync(audio, connectionString, containerName);

                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

                speechConfig.SpeechRecognitionLanguage = "pt-BR";

                var textoConvertido = await _speechService.AudioToText(speechConfig, uriAudioBlob);

                //se der erro, atribuir esse await a uma variavel e passa-la no return
                return StatusCode(200, textoConvertido);
            }
            catch (Exception e)
            {

                return BadRequest($"ERRO! {e.Message}");
            }
        }


    }
}
