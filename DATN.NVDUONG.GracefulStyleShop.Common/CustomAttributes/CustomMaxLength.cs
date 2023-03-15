using MDATN.NVDUONG.GracefulStyleShop.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.CustomAttributes
{
    public class CustomMaxLengthAttribute : MaxLengthAttribute
    {
        private int _length;
        #region Contructor
        public CustomMaxLengthAttribute(int length)
            : base()
        {
            _length = length;
        }
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
            return String.Format(name + " " + ResourceVN.InValidMaxLength, _length);
        }

        /// <summary>
        /// Override hàm check validate
        /// </summary>
        /// <param name="value">Giá trị</param>
        /// <returns>Trả ra true - false</returns>
        /// CreatedBy: NVD (9/2/2023)
        public override bool IsValid(object? value)
        {
            if(value.ObjToStr() == "")
                return true;

            return value.ObjToStr().Length <= _length;
        }
        #endregion
    }
}
