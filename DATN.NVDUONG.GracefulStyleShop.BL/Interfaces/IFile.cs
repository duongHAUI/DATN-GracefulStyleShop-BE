using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Interfaces
{
    public interface IFile
    {
        public ServiceResult Insert(FileModel fileModel);
    }
}
