using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Enums
{
    /// <summary>
    /// Enum mã lỗi
    /// </summary>
    /// CreatedBy: NVD (7/2/2023)
    public static class EnumErrorCode
    {
        /// <summary>
        /// Dữ liệu không có
        /// </summary>
        /// CreatedBy: NVD (7/2/2023)
        public static int NOT_CONTENT = 0;

        /// <summary>
        /// Lỗi validate
        /// </summary>
        /// CreatedBy: NVD (7/2/2023)
        public static int BADREQUEST = 1;

        /// <summary>
        /// Lỗi Server
        /// </summary>
        /// CreatedBy: NVD (7/2/2023)
        public static int SERVER_ERROR = 2;
    }
}
