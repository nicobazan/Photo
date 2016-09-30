using KUDOS.Controllers.InsertRequest;

namespace KUDOS.Services
{
    public interface IFileService
    {
        int Insert(AWSUploadInsertRequest model);
    }
}