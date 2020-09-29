using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Services
{
    public class ImageStoreService: IImageStoreService
    {
        private IDapperHelper _dapperHelper;
        public ImageStoreService(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }
        public int StoreWebCamImage(ImageStore model)
        {
            var dbrPar = new DynamicParameters();
            dbrPar.Add("ImageUrl", model.ImageUrl, DbType.String);

            var data = _dapperHelper.Insert<int>("[dbo].[SP_Store_Image]", dbrPar, CommandType.StoredProcedure);
            return data;
        }
    }
}
