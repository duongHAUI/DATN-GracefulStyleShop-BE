using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Constants
{
    public static class NameProduceConstants
    {
        /// <summary>
        /// Store lấy tất cả dữ liệu
        /// </summary>
        public static string GetByAll = "Proc_{0}_GetAll";

        /// <summary>
        // Store lấy dữ liệu có bộ lọc
        /// </summary>
        /// 
        public static string GetByFilter = "Proc_{0}_GetByFilter";

        /// <summary>
        // Store lấy mã code mới
        /// </summary>
        /// 
        public static string GetNewCode = "Proc_{0}_GetNewCode";

        /// <summary>
        // Store lấy mã max
        /// </summary>
        /// 
        public static string GetMaxCode = "Proc_{0}_GetMaxCode";

        /// <summary>
        // Store lấy đối tượng theo ID
        /// </summary>
        /// 
        public static string GetById = "Proc_{0}_GetById";

        /// <summary>
        // Store lấy đối tượng theo số cmnd
        /// </summary>
        /// 
        public static string GetByIdentityNumber = "Proc_{0}_GetByIdentityNumber";

        /// <summary>
        // Store lấy đối tượng theo mã
        /// </summary>
        /// 
        public static string GetByCode = "Proc_{0}_GetByCode";

        /// <summary>
        // Store lấy đối tượng theo tên
        /// </summary>
        /// 
        public static string GetByName = "Proc_{0}_GetByName";

        /// <summary>
        // Store thêm bản ghi
        /// </summary>
        /// 
        public static string Insert = "Proc_{0}_Insert";

        /// <summary>
        // Store sửa bản ghi
        /// </summary>
        /// 
        public static string Update = "Proc_{0}_Update";

        /// <summary>
        // Store xóa bản ghi
        /// </summary>
        /// 
        public static string Delete = "Proc_{0}_Delete";

        /// <summary>
        // Store nhiều bản ghi
        /// </summary>
        /// 
        public static string DeleteRecords = "Proc_{0}_DeleteRecords";
    }
}
