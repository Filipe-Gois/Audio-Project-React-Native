using Azure.Storage.Blobs;

namespace WebAPI.Utils.BlobStorage
{
    public static class AzureBlobStorageHelper
    {

        //passar a extensao do arquivo para .wav
        public static async Task<string> UploadAudioBlobAsync(IFormFile audio, string stringConexao, string nomeContainer)
        {
            try
            {
                if (audio != null)
                {
                    //Path.GetExtension(arquivo.FileName): pega o nome do arquivo e obtém a extensao dele. Ex: A754E556CFD4457D908D309849E44475.png

                    //gera um nome unico + extensao do arquivo
                    var blobName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(audio.FileName);


                    //cria uma instancia do cliente blob service e passa a string de conexao
                    var blobServiceClient = new BlobServiceClient(stringConexao);

                    //obtem um containerclient usando o nome do container dp blob
                    var blobContainerClient = blobServiceClient.GetBlobContainerClient(nomeContainer);

                    //obtem um blob client usando o blob name
                    var blobClient = blobContainerClient.GetBlobClient(blobName);

                    //abre o fluxo de entrada do arquivo(foto)
                    using (var stream = audio.OpenReadStream())
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
                    return "https://blobvitalhubfilipegoisg2.blob.core.windows.net/containervitalhubfilipegoisg2/defaultImage.png";
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
