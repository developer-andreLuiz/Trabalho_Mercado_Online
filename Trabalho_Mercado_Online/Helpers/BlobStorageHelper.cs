using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;
namespace Trabalho_Mercado_Online.Helpers
{
    class BlobStorageHelper
    {
        static string conexao = "DefaultEndpointsProtocol=https;AccountName=mercadoonline;AccountKey=MYYikySbsnSdc35De4TK/ps6vVHQuqukZR3fWcbL3Vf7E75FquylKltG9VvDE6eQtqD/9yYmW360+AStejyEgg==;EndpointSuffix=core.windows.net";
        string chave = "MYYikySbsnSdc35De4TK/ps6vVHQuqukZR3fWcbL3Vf7E75FquylKltG9VvDE6eQtqD/9yYmW360+AStejyEgg==";
        public static void Upload(string conteinerLocal , string nomeImagemLocal, string pathLocal)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(conexao);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(conteinerLocal);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(nomeImagemLocal+".jpg");
            blob.UploadFromFileAsync(pathLocal);
        }
        public static void Deletar(string conteinerLocal, string nomeImagemLocal)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(conexao);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(conteinerLocal);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(nomeImagemLocal + ".jpg");
            blob.DeleteIfExistsAsync();
        }

    }
}
