using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class CartDL : BaseDL<Cart>,ICartDL
    {
        public CartDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public int CartNumber(Guid CustomerId)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format("Proc_Cart_CartNumber", tableName);

                var parameters = new DynamicParameters();
                parameters.Add("p_CustomerId" , CustomerId);

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                int cartNumber = _databaseConnection.QueryFirstOrDefault<int>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                
                // Đóng kết nối
                _databaseConnection.Close();

                return cartNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public override PagingResult<Cart> GetByFilter(object parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                //var ProductDB = result.Read<ProductDB>();
                var productDictionary = new Dictionary<Guid, Cart>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Cart, Image, Cart>(
                                    storedProducedureName,
                                    (cart, image) =>
                                    {
                                        Cart cartEntry;
                                        if (!productDictionary.TryGetValue(cart.CartId, out cartEntry))
                                        {
                                            cartEntry = cart;
                                            cartEntry.Images = new List<Image>();
                                            productDictionary.Add(cartEntry.CartId, cartEntry);
                                        }

                                        cartEntry.Images.Add(image);
                                        return cartEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();
                var data = new PagingResult<Cart>
                {
                    Total = result.Count(),
                    Data = result.ToList()
                };
                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
