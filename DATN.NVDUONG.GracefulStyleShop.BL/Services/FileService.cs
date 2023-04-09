using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class FileService : IFileService
    {
        private IFileDL _fileDL;
        public FileService(IFileDL fileDL)
        {
            _fileDL = fileDL;
        }

        public ServiceResult Insert(FileModel fileModel)
        {

            var listImageDelete = new List<Guid>();
            var listImageinsert = new List<Image>();
            //// lấy các ảnh hiện có 
            //List<Image> listImage = _fileDL.GetFileByObjectId(fileModel.ObjectId);

            //if (fileModel.Images.Count == 0)
            //{
            //    listImageDelete = listImage.Select(x => x.ImageId).ToList();
            //}
            //else
            //{
            //    listImage.ForEach(image =>
            //    {
            //        if (fileModel.Images.Where(x => x == image.ImageId).Count() == 0)
            //        {
            //            listImageDelete.Add(image.ImageId);
            //        }
            //    });
            //}

            //// xóa
            //var res = _fileDL.DeleteFile(listImageDelete);

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),"images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            foreach (var file in fileModel.Files)
            {
                var newGuid = Guid.NewGuid();
                // Tạo tên file mới để tránh bị trùng lặp
                var uniqueFileName = newGuid.ToString() + "_" + file.FileName;

                // Lưu ảnh vào thư mục uploads/images
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }

                listImageinsert.Add(new Image()
                {
                    ImageId = newGuid,
                    ProductId = fileModel.ObjectId,
                    ImageLink = filePath,
                    ImageName = file.FileName
                });
            }

            foreach (var item in listImageinsert)
            {
                _fileDL.Insert(item);
            }

            return new ServiceResult();
        }
    }
}
