using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Interfaces
{
    /// <summary>
    /// Base Service
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// CreatedBy : NVDuong (2/2/2023)
    public interface IBaseService<Entity>
    {
        #region Method
        /// <summary>
        /// Lấy danh sách
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public object GetAll();

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public object GetByFilter(object parameters);

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public Entity GetById(Guid id);

        /// <summary>
        /// Thêm vào dữ liệu 
        /// </summary>
        /// <param name="enity"></param>
        /// CreatedBy : NVDuong (2/2/2023)
        public ServiceResult Insert(Entity enity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="enity"></param>
        /// <returns></returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public ServiceResult Update(Guid id, Entity enity);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool Delete(Guid id);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool DeleteRecords(List<Guid> listId);
        #endregion
    }
}
