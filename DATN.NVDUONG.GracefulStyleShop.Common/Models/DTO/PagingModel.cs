namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    /// <summary>
    /// Class pagging chung
    /// </summary>
    /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
    public class PagingModel
    {
        /// <summary>
        /// Số trang trên 1 page
        /// </summary>
        /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
        public int pageSize { get; set; } = 20;

        /// <summary>
        /// Vị trí page
        /// </summary>
        /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
        public int pageNumber { get; set; } = 1;

        /// <summary>
        /// Text tìm kiếm
        /// </summary>
        /// CreatedBy : Nguyễn Văn Dương (16/1/2023)
        public string? textSearch { get; set; }
    }
    
}
