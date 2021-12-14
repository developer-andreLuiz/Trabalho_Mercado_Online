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
        static string conexao = "DefaultEndpointsProtocol=https;AccountName=aplicativo;AccountKey=96sAG8n4AbME4aiJwlRNq1ECtl/I7tKXpPYn37w8YO3pY+I3l5tccWh+CUmG7rqSulrwSqrm42o8e5g7JrNK8w==;EndpointSuffix=core.windows.net";
        string chave = "96sAG8n4AbME4aiJwlRNq1ECtl/I7tKXpPYn37w8YO3pY+I3l5tccWh+CUmG7rqSulrwSqrm42o8e5g7JrNK8w==";

        /* Nome dos conteiners
         categoriasnivel1
         categoriasnivel2
         categoriasnivel3
         produtos
         
         */

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
