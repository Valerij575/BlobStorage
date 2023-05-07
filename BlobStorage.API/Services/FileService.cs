using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorage.API.Models;
using System.IO;

namespace BlobStorage.API.Services
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            if(!await blobClient.ExistsAsync())
            {
                return false;
            }

            var result = await blobClient.DeleteAsync();
            var status = result.Status;
            return true;
        }

        public async Task<FileStorage> Downloadfile(string fileName)
        {
            
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            var responce = await blobClient.DownloadContentAsync();
            var contentType = (await blobClient.GetPropertiesAsync()).Value.ContentType;
            var stream = responce.Value.Content;

            return new FileStorage()
            {
                FileStream = stream.ToArray(),
                ContentType = contentType,
                FileName = fileName
            };
        }

        public async Task UploadFile(IFormFile file)
        {
            var contents = file.ContentType.Split('\\');
            var fileType = contents.First();
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(fileType);
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobName = Path.GetFileName(file.FileName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            using(var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }
        }
    }
}
