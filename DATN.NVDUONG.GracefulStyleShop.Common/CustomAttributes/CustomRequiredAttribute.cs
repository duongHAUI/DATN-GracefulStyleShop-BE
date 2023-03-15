using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using MDATN.NVDUONG.GracefulStyleShop.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.CustomAttributes
{
    /// <summary>
    /// Class custom lại sttribute Required bắn lỗi
    /// </summary>
    /// CreatedBy: NVD (9/2/2023)
    public class CustomRequiredAttribute : RequiredAttribute
    {
        #region Contructor
        public CustomRequiredAttribute() { } 
        #endregion

        #region Method
        /// <summary>
        /// Override hàm hiển thị lỗi
        /// </summary>
        /// <param name="name">Display name</param>
        /// <returns>Format lỗi mong muốn</returns>
        /// CreatedBy: NVD (9/2/2023)
        public override string FormatErrorMessage(string name)
        {
            return name + " " + ResourceVN.NotEmtity;
        }

        /// <summary>
        /// Override hàm check validate
        /// </summary>
        /// <param name="value">Giá trị</param>
        /// <returns>Trả ra true - false</returns>
        /// CreatedBy: NVD (9/2/2023)
        public override bool IsValid(object? value)
        {
            return !string.IsNullOrEmpty(value.ObjToStr().Trim());
        } 
        #endregion
    }
}
