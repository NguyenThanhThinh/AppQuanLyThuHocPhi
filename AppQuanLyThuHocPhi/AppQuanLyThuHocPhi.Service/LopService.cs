using AppQuanLyThuHocPhi.Data;
using AppQuanLyThuHocPhi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Service
{
    public interface ILopService
    {
        List<Lop> GETALL();
    }
    public class LopService : ILopService
    {
        private IUnitOfWork _unitOfWork;
        public LopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Lop> GETALL()
        {
            return _unitOfWork.LopRepo.GetAllLop();
        }
    }
}
