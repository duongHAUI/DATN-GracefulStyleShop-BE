using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using System.Collections;
using System.Net;

namespace DATN.NVDUONG.GracefulStyleShop.Common
{
    /// <summary>
    /// Class bắn lỗi exception
    /// </summary>
    /// CreatedBy: NVD (1/2/2023)
    public class MExceptionResponse : Exception
    {
        #region Field
        public Dictionary<string, string>? objMessageError;
        public string? msgError;
        public string msgUser = ResourceVN.ErrorServer;
        public int? errorCode = EnumErrorCode.SERVER_ERROR;
        #endregion

        #region Contructor
        /// <summary>
        /// Contructor 1 đối số
        /// </summary>
        /// <param name="msgError">Lỗi</param>
        /// CreatedBy: NVD(11/2/2023)
        public MExceptionResponse(string? msgError = null)
        {
            this.msgError = msgError;
        }

        /// <summary>
        /// Contructor không đối số
        /// </summary>
        /// CreatedBy: NVD(11/2/2023)
        public MExceptionResponse() { }
        #endregion

        #region Method
        /// <summary>
        /// Gán lỗi
        /// </summary>
        /// CreatedBy: NVD (1/2/2023)
        public override string Message => this.msgError;

        /// <summary>
        /// Gán chi tiết lỗi
        /// </summary>
        /// CreatedBy: NVD (1/2/2023)
        public override IDictionary Data => this.objMessageError; 
        #endregion
    }
}
