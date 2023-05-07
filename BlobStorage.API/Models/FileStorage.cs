namespace BlobStorage.API.Models
{
    public class FileStorage
    {
        public byte[] FileStream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
