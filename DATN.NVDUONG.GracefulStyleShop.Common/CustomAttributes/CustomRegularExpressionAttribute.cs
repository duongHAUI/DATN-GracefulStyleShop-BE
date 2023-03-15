using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using MDATN.NVDUONG.GracefulStyleShop.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.CustomAttributes
{
    /// <summary>
    /// Class custom lại sttribute RegularExpression bắn lỗi
    /// </summary>
    /// CreatedBy: NVD (9/2/2023)
    public class CustomRegularExpressionAttribute : RegularExpressionAttribute
    {
        #region Contructor
        public CustomRegularExpressionAttribute(string pattern) : base(pattern)
        {
        } 
        #endregion

        #region Method
        /// <summary>
        /// Override hàm hiển thị lỗi
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Format lỗi mong muốn</returns>
        /// CreatedBy: NVD (9/2/2023)
        public override string FormatErrorMessage(string name)
        {
            return name + " " + ResourceVN.NcorrectFormat;
        }

        /// <summary>
        /// Override hàm check validate
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Trả ra true - false</returns>
        /// CreatedBy: NVD (9/2/2023)
        public override bool IsValid(object? value)
        {
            if (value.ObjToStr().Trim() == "")
                return true;

            var str = value.ObjToStr();

            return Regex.IsMatch(str, Pattern);
        } 
        #endregion
    }
}
