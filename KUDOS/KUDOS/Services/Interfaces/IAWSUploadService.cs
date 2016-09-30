using System.IO;

namespace KUDOS.Services
{
    public interface IAWSUploadService
    {
        bool UploadFile(string key, Stream stream);
        void uploadService();
    }
}