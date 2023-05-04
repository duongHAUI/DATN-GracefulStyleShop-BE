using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class OrderDL : BaseDL<Order>, IOrderDL
    {
        public OrderDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        //public virtual PagingResult<object> GetByFilter(dynamic parametersFilter)
        //{
        //    try
        //    {
        //        // Tên store produce
        //        string storedProducedureName = string.Format(NameProduceConstants.GetByFilter, tableName);

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@TotalRecords", direction: ParameterDirection.Output);
        //        foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
        //        {
        //            // Add parameters
        //            parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
        //        }

        //        // Mở kết nối
        //        _databaseConnection.Open();

        //        // Xử lý lấy dữ liệu trong stored
        //        var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);

        //        var data = new PagingResult<object>()
        //        {
        //            Data = result.Read<object>().ToList(),
        //            Total = parameters.Get<int>("@TotalRecords")
        //        };

        //        // Đóng kết nối
        //        _databaseConnection.Close();

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        _databaseConnection.Close();
        //        throw new MExceptionResponse(ex.Message);
        //    }
        //}

        public override Order GetById(Guid id)
        {
            try
            {
                var order = new Order();
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetById, tableName);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                var orderDictionary = new Dictionary<Guid, Order>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Order>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

                order = result.GroupBy(x => x.OrderId).Select(x => new Order
                {
                    OrderId = x.Key,
                    OrderCode = x.Select(x => x.OrderCode).FirstOrDefault(),
                    Status = x.Select(x => x.Status).FirstOrDefault(),
                    ShipmentName = x.Select(x => x.ShipmentName).FirstOrDefault(),
                    CancelReason = x.Select(x => x.CancelReason).FirstOrDefault(),
                    CreatedAt = x.Select(x => x.CreatedAt).FirstOrDefault(),
                    AddressDetail = x.Select(x => x.AddressDetail).FirstOrDefault(),
                    Phone = x.Select(x => x.Phone).FirstOrDefault(),
                    Receiver = x.Select(x => x.Receiver).FirstOrDefault(),
                    OrderDetails = x.Select(y => new OrderDetail
                    {
                        OrderDetailId = y.OrderDetailId,
                        Quantity = y.Quantity,
                        PriceSale = y.PriceSale,
                        ImageLink = y.ImageLink,
                        ProductName = y.ProductName,
                        ColorName = y.ColorName,
                        SizeCode = y.SizeCode
                    }).ToList()
                }).ToList()[0];

                // Đóng kết nối
                _databaseConnection.Close();

                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public bool Insert(Order order, List<OrderDetail> orderDetails, Guid customerId)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.Insert, tableName);

                // Chuẩn bị parameters cho stored produce
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in order.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType == typeof(List<OrderDetail>))
                        continue;
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(order));
                }

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);
                if(res > 0)
                {
                    string queryCustom = "";

                    orderDetails.ForEach(x =>
                    {
                        queryCustom += $"UPDATE productvariant p SET p.Quantity = p.Quantity - {x.Quantity} WHERE p.ProductVariantId = '{x.ProductVariantId}';" +
                        $"UPDATE product p SET p.Quantity = p.Quantity - {x.Quantity}, p.Sold = p.Sold + {x.Quantity} WHERE p.ProductId = (SELECT p.ProductId FROM productvariant p WHERE p.ProductVariantId = '{x.ProductVariantId}');";
                    });

                    res = _databaseConnection.InsertRecords<OrderDetail>(orderDetails,queryCustom);

                    if(res > 0)
                    {
                        string query = $"delete from Cart where CustomerId = '{customerId}'";
                        res = _databaseConnection.Execute(query, commandType: CommandType.Text);
                    }
                    if (res > 0) _databaseConnection.CommitTransaction();
                    else
                    {
                        _databaseConnection.RollbackTransaction();
                    }
                }
                // Đóng kết nối
                _databaseConnection.Close();

                //Trả kết quả về
                return res == 0 ? false : true;
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
