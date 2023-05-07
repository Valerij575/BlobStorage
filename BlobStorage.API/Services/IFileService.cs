using BlobStorage.API.Models;

namespace BlobStorage.API.Services
{
    public interface IFileService
    {
        Task UploadFile(IFormFile file);
        Task<FileStorage> Downloadfile(string fileName);
        Task<bool> DeleteFile(string fileName);
    }
}
