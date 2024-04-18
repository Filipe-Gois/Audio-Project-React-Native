using Azure.Storage.Blobs;
using CodingDojoSpeechService.Domains;

namespace WebAPI.Utils.BlobStorage
{
    public static class AzureBlobStorageHelper
    {

        //passar a extensao do arquivo para .wav
        public static async Task<string> UploadAudioBlobAsync(Audio audio, string stringConexao, string nomeContainer)
        {
            try
            {
                //validar caso seja nulo
                //var fileExtension = Path.GetExtension(audio.AudioFile!.FileName);



                //verifica se o usuario inseriu um arquivo e é um audio
                // && fileExtension == ".aiff" || fileExtension == ".au" || fileExtension == ".mid" || fileExtension == ".midi" || fileExtension == ".mp3" || fileExtension == ".m4a" || fileExtension == ".mp4" || fileExtension == ".wav" || fileExtension == ".wma" || fileExtension == ".ogg"
                if (audio.AudioFile != null)
                {
                    //Path.GetExtension(arquivo.FileName): pega o nome do arquivo e obtém a extensao dele. Ex: A754E556CFD4457D908D309849E44475.png

                    //gera um nome unico + extensao do arquivo
                    //.split('.') --- divide o blob name em um array contendo duas strings (guid do arquivo e sua extensão)
                    var blobName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(audio.AudioFile!.FileName);




                    ///lógica para pegar a extensao do arquivo e alterar para .wav *tentar usar regex depois*

                    //separa o id do arquvio de sua extensao para trata-la
                    string[] blobNameFormated = blobName.Split('.');


                    if (blobNameFormated[1] != "wav")
                    {
                        blobNameFormated[1] = ".wav";
                        blobName = string.Concat(blobNameFormated);
                    }


                    //cria uma instancia do cliente blob service e passa a string de conexao
                    var blobServiceClient = new BlobServiceClient(stringConexao);

                    //obtem um containerclient usando o nome do container dp blob
                    var blobContainerClient = blobServiceClient.GetBlobContainerClient(nomeContainer);

                    //obtem um blob client usando o blob name
                    var blobClient = blobContainerClient.GetBlobClient(blobName);

                    //abre o fluxo de entrada do arquivo(foto)
                    using (var stream = audio.AudioFile.OpenReadStream())
                    {

                        //carrega o arquivo para o blob storage de forma assincrona
                        await blobClient.UploadAsync(stream, true);
                    }

                    //retorna a uri do blob como uma string
                    return blobClient.Uri.ToString();
                }
                else
                {
                    //retorna a uri de uma imagem padrao caso nenhum arquivo seja enviado
                    throw new Exception("Insira um arquivo de áudio.");
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
