using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;
using KUDOS.Controllers.Domain;
using System.IO;
using KUDOS.Response;
using KUDOS.Services;
using KUDOS.Controllers.InsertRequest;

namespace KUDOS.Controllers.ApiControllers

{


    [RoutePrefix("api/awsupload")]
    public class AWSUploadApiController : ApiController
    {
        private IAWSUploadService _AWSUploadService;
        private IFileService _FileSevice;

        public void UploadApiController(IAWSUploadService AWSUploadService, IFileService FileService)
        {
            _AWSUploadService = AWSUploadService;
            _FileSevice = FileService;
        }

        [HttpPost]
        [Route("uploadimage")]
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            InMemoryMultipartStreamProvider provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartStreamProvider>(new InMemoryMultipartStreamProvider());

            NameValueCollection formData = provider.FormData;

            IList<HttpContent> files = provider.Files;

            List<FileUpload> List = new List<FileUpload>();

            foreach (HttpContent file in files)
            {
                Stream fileStream = await file.ReadAsStreamAsync();

                FileUpload fileDesc = new FileUpload();
                fileDesc.Name = file.Headers.ContentDisposition.FileName;
                string fileName = fileDesc.Name.Replace("\"", string.Empty);
                fileDesc.Path = "/Photo/KUDOS/" + fileName;

                _AWSUploadService.UploadFile(fileName, fileStream);

                AWSUploadInsertRequest model = new AWSUploadInsertRequest();
                model.FileName = fileName;
                model.FilePath = fileDesc.Path;
                model.AwsBucket = "photobucketmarkphoto";

                var id = _FileSevice.Insert(model);
                fileDesc.id = id;

                List.Add(fileDesc);

            }

            ItemsResponse<FileUpload> response = new ItemsResponse<FileUpload>();
            response.Items = List;

            return this.Request.CreateResponse(response);

        }



    }
}

