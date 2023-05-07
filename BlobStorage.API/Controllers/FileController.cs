using BlobStorage.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Route("upload")]
        public  async Task<IActionResult> Upload(IFormFile file)
        {
            if(file is null || file.Length == 0)
            {
                return BadRequest("No file was selected for upload");
            }

            await _fileService.UploadFile(file);

            return Ok("File uploaded successfully");
        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is required for download");
            }

            var result = await _fileService.Downloadfile(fileName);
            return File(result.FileStream, result.ContentType, result.FileName);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is required for deleted");
            }

            await _fileService.DeleteFile(fileName);

            return Ok("File deleted");
        }
    }
}
