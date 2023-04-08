using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    /// <summary>
    /// Dữ liệu trả về dữ liệu đối tượng
    /// </summary>
    /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
    public class PagingResult<T>
    {
        /// <summary>
        /// Tổng số bản ghi filter
        /// </summary>
        /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
        public int Total { get; set; }

        /// <summary>
        /// Dữ liệu list
        /// </summary>
        /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
        public List<Object> Data { get; set; }
    }
}
