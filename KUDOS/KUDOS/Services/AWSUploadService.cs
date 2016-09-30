using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace KUDOS.Services


{


    public class AWSUploadService : BaseService, IAWSUploadService
    {
        private IAmazonS3 clientx = null;
        private const string awsBucketName = "photobucketmarkphoto";

        public void uploadService()
        {
            string accessKey = ConfigurationManager.AppSettings["AWSAccessKeyId"];
            string secretKey = ConfigurationManager.AppSettings["AWSSecretKey"];

            if (this.clientx == null)
            {
                this.clientx = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.USWest1);
            }

        }
        public bool UploadFile(string key, Stream stream)
        {
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                BucketName = awsBucketName,
                CannedACL = S3CannedACL.AuthenticatedRead,
                Key = key
            };

            TransferUtility fileTransferUtility = new TransferUtility(this.clientx);
            fileTransferUtility.Upload(uploadRequest);
            return true;
        }



    }
}

 