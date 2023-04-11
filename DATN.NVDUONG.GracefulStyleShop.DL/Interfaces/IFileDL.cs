using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    public interface IFileDL
    {
        public bool Insert(List<Image> images);

        public List<Image> GetFileByObjectId(Guid id);

        public bool DeleteFile(List<Guid> listId);
    }
}