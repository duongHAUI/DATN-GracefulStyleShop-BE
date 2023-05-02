using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    /// <summary>
    /// Xử lý logic và lấy dữ liệu base
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public class BaseService<Entity>: IBaseService<Entity>
    {
        #region Field
        protected Dictionary<string, string> listErrorValidate = new Dictionary<string, string>();
        protected IBaseDL<Entity> _baseDL;
        #endregion

        #region Contructor
        public BaseService(IBaseDL<Entity> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public virtual object GetByFilter(object parameters)
        {
            return _baseDL.GetByFilter(parameters);
        }

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng</returns>
        public Entity GetById(Guid id)
        {
            return _baseDL.GetById(id);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="enity">Đối tượng</param>
        /// <returns>Danh sách nhân viên</returns>
        public virtual ServiceResult Insert(Entity enity)
        {
            dynamic result;
            var isValid = this.IsValidate(enity);

            // Kiểm tra validate
            if (isValid)
            {
                enity = AddProperties(enity, true,null,out Guid id);

                bool response = _baseDL.Insert(enity);
                if(!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);
                else result = new ServiceResult(id);
            }else
            {
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="enity">Đối tượng</param>
        /// <returns>Danh sách nhân viên</returns>
        public ServiceResult Update(Guid id, Entity enity)
        {
            dynamic result;
            enity = AddProperties(enity, false, id,out id);

            var isValid = this.IsValidate(enity, false);

            if (isValid)
            {
                // Gán dữ liệu
                bool response = _baseDL.Update(enity);

                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);
                else result = new ServiceResult(id);
            }else{
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }
        /// <summary>
        /// Kiem tra dữ liệu đầu vào hợp lệ
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <param name="isInsert">Insert hay Update</param>
        /// <returns>Ket qua validate</returns>
        public bool IsValidate(Entity entity, bool isInsert = true)
        {
            var validationResults = new List<ValidationResult>();

            // Kiểm tra attribute hợp lệ của dữ liệu
            if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
            {
                foreach (var item in validationResults)
                {
                    listErrorValidate.Add(item.MemberNames.First(),item.ErrorMessage is null ? "" : item.ErrorMessage);
                }
            }

            // Kiểm tra lỗi riêng
            ValidateCustom(entity, isInsert);

            // Check có lỗi hay không
            if (listErrorValidate.Count > 0) return false;

            return true;
        }

        /// <summary>
        /// Hàm validate custom để đối tượng con có thể ghi đè
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <param name="isInsert">Action</param>
        public virtual void ValidateCustom(Entity entity, bool isInsert = true) { }

        /// <summary>
        /// Hàm thêm propery cần thiết
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <param name="isInsert">Insert hoặc update</param>
        /// <param name="entityId">Id ban ghi insert</param>
        /// <returns>Đối tượng đầy đủ</returns>
        public Entity AddProperties(dynamic entity, bool isInsert, Guid? entityId, out Guid newId)
        {
            entity.ModifiedAt = DateTime.Now;
            if (isInsert)
            {
                entity.CreatedAt = DateTime.Now;
                entity.GetType().GetProperty($"{typeof(Entity).Name}Id").SetValue(entity, Guid.NewGuid(), null);
            }
            else entity.GetType().GetProperty($"{typeof(Entity).Name}Id").SetValue(entity, entityId, null);

            newId = entity.GetType().GetProperty($"{typeof(Entity).Name}Id").GetValue(entity, null);

            return processPropertyCustom(entity);
        }

        public virtual Entity processPropertyCustom(Entity entity)
        {
            return entity;
        }

        /// <summary>
        /// Khóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public virtual bool DeleteRecords(List<Guid> listId)
        {
            return _baseDL.DeleteRecords(listId);
        }
        public bool LockUpRecords(List<Guid> listId)
        {
            return _baseDL.LockUpRecords(listId);
        }
        #endregion
    }
}
