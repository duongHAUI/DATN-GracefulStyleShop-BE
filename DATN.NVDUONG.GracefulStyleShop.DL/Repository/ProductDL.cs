using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System.Collections.Specialized;
using System.Data;
using static Dapper.SqlMapper;
using System.Reflection;
using System.Reflection.Metadata;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        private IDatabaseConnection _databaseConnection;
        public ProductDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public override PagingResult<Product> GetByFilter(object parametersFilter)
        {
            try
            {
                var data = new PagingResult<Product>();
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords", direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProducedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;

                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }

                                        productEntry.Images.Add(image);
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();
                // Lấy số lượng 
                storedProducedureName = "Proc_Product_GetTotalRecords";
                var total = _databaseConnection.QueryFirstOrDefault<int>(storedProducedureName, new { }, commandType: CommandType.StoredProcedure);

                data.Data = result.ToList();
                data.Total = total;


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

        public override Product GetById(Guid id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetById, typeof(Product).Name);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProducedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;

                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }

                                        productEntry.Images.Add(image);
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parametes,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();

                // Đóng kết nối
                _databaseConnection.Close();

                return result[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public bool UpdateSold(Guid productId, int sold)
        {
            try
            {
                string query = $"Update {tableName} set Sold = {sold} where {tableName}Id = {productId}";

                //Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu số lượng bán
                int numberUpdate = _databaseConnection.Execute(query, commandType: CommandType.Text);
                if (numberUpdate == 0)
                {
                    return false;
                }
                _databaseConnection.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

    }
}
