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
using System.Security.Cryptography;

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
        public object GetByFilterDetail(object parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilterDetail, tableName);

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
                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new Image()
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    ProductVariants = x.GroupBy(x => new { x.ProductVariantId , x.ColorId } ).Select(x => new ProductVariant()
                    {
                        ProductVariantId = x.Key.ProductVariantId,
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        Sizes = x.GroupBy(x => x.SizeId).Select(x => new Size()
                        {
                            SizeId = x.Key,
                            SizeCode = x.Select(x => x.SizeCode).FirstOrDefault()
                        }).ToList()
                    }).ToList()
                }).ToList();


                var data = new
                {
                    Total = productRespone.Count(),
                    Data = productRespone.ToList()
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

                return new Product();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object GetByIDDetail(Guid id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByIdDetail, typeof(Product).Name);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    Colors = x.GroupBy(x => new {x.ColorId }).Select(x => new 
                    {
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        ColorName = x.Select(x => x.ColorName).FirstOrDefault(),
                        Sizes = x.GroupBy(x => new { x.SizeId,x.ProductVariantId}).Select(x => new 
                        {
                            ProductVariantId = x.Key.ProductVariantId,
                            SizeId = x.Key.SizeId,
                            Quantity = x.Key.ProductVariantId,
                            SizeCode = x.Select(x => x.SizeCode).FirstOrDefault(),
                            ProductVariantQuantity = x.Select(x => x.ProductVariantQuantity).FirstOrDefault()
                        }).ToList()
                    }).ToList(),
                    Sizes = x.GroupBy(x => x.SizeId).Select(x => new
                    {
                        SizeId = x.Key,
                        SizeCode = x.Select(x => x.SizeCode).FirstOrDefault(),
                    }).ToList(),
                }).ToList().ElementAt(0);

                // Đóng kết nối
                _databaseConnection.Close();

                return productRespone;
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
