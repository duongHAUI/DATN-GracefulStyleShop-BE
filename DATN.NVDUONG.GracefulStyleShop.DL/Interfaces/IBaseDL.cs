

using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    /// <summary>
    /// Base interface Repository
    /// </summary>
    /// CreatedBy : NVDuong (2/2/2023)
    public interface IBaseDL<Entity>
    {
        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public PagingResult<Entity> GetAll();

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public PagingResult<Entity> GetByFilter(object parameters);

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public Entity GetById(Guid id);

        /// <summary>
        /// Lấy thông tin theo mã
        /// </summary>
        /// <param name="EntityCode">Mã đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public Guid GetByCode(string EntityCode);

        /// <summary>
        /// Lấy thông tin theo tên
        /// </summary>
        /// <param name="EntityName">Tên đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public Guid GetByName(string EntityName);

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thêm</param>
        /// <returns>0 : thất bại - 1 : thành công</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool Insert(Entity entity);

        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng update</param>
        /// <returns>0 : thất bại - 1 : thành công</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool Update(Entity entity);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">ID đối tượng xóa</param>
        /// <returns>true - false</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool Delete(Guid id);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy : NVDuong (2/2/2023)
        public bool DeleteRecords(List<Guid> listId);
    }
}
