using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    /// <summary>
    /// Đầu vào xử lý file import
    /// </summary>
    /// CreatdBy : NVD (17/2/2023)
    public class ImportEmployeeInput
    {
        #region Properties
        /// <summary>
        /// File đầu vào
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        //public List<EmployeeImport> employees { get; set; }
        #endregion
    }
}
