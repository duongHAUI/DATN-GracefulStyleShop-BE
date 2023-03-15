using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    /// <summary>
    /// Đối tượng nhân viên import khi kiểm tra hợp lệ
    /// </summary>
    /// CreatedBy : NVDuong (17/2/2023)
    public class EmployeeImport 
    {
        /// <summary>
        /// Dòng số mấy trong file
        /// </summary>
        public int rowIndex { get; set; }

        /// <summary>
        /// Mã trạng thái
        /// </summary>
        public EnumStatusRowCodeImport StatusCode { get; set; }

        /// <summary>
        /// Trạng thái dòng
        /// </summary>
        public string StatusTitle { get; set; }

        /// <summary>
        /// Chi tiết lỗi
        /// </summary>
        public string MessageDetail { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }
    }

    /// <summary>
    /// Đối tượng danh sách nhân viên import sau khi khi kiểm tra hợp lệ
    /// </summary>
    /// CreatedBy : NVDuong (17/2/2023)
    public class ValidateEmployeeImportResponse
    {
        /// <summary>
        /// Số dòng hợp lệ
        /// </summary>
        public int numberRowValid { get; set; }

        /// <summary>
        /// Số dòng không hợp lệ
        /// </summary>
        public int numberRowInValid { get; set; }

        /// <summary>
        /// Tổng số dòng import
        /// </summary>
        public int totalRow { get; set; }

        /// <summary>
        /// Danh sách nhân viên import
        /// </summary>
        public List<EmployeeImport> data { get; set; }
    }
}
