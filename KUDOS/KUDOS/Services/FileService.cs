using KUDOS.Controllers.InsertRequest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KUDOS.Services
{
    public class FileService : BaseService, IFileService
    {

        public int Insert(AWSUploadInsertRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ImageFiles_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {

                   paramCollection.AddWithValue("@FileName", model.FileName);
                   paramCollection.AddWithValue("@FilePath", model.FilePath);
                   paramCollection.AddWithValue("@AwsBucket", model.AwsBucket);
                   


                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;
        }




    }
}