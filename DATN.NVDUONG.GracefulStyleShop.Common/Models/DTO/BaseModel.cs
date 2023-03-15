using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    public class BaseModel
    {
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        /// CreatedBy: (16/1/2023)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy: (16/1/2023)
        public string CreatedBy { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        /// CreatedBy: (16/1/2023)
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Thời gian sửa gần nhất
        /// </summary>
        /// CreatedBy: (16/1/2023)
        public DateTime? ModifiedDate { get; set; }
    }
}
