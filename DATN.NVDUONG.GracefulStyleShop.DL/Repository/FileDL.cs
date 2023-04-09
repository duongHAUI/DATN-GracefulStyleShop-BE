using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class FileDL : IFileDL
    {
        #region Field
        protected string tableName;
        protected IDatabaseConnection _databaseConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public FileDL(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public bool DeleteFile(List<Guid> listId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Image image)
        {
            // Tên store produce
            string storedProducedureName = string.Format(NameProduceConstants.Insert, "Image");

            // Chuẩn bị parameters cho stored produce
            var parameters = new DynamicParameters();
            foreach (PropertyInfo propertyInfo in image.GetType().GetProperties())
            {
                // Add parameters
                parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(image));
            }

            // Mở kết nối
            _databaseConnection.Open();

            // Xử lý thêm dữ liệu trong stored
            int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);

            // Đóng kết nối
            _databaseConnection.Close();

            //Trả kết quả về
            return res == 0 ? false : true;
        }

        List<Image> IFileDL.GetFileByObjectId(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
