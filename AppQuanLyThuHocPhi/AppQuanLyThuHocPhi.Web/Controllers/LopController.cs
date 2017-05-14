using AppQuanLyThuHocPhi.Data.Repositories;
using AppQuanLyThuHocPhi.Entities.Models;
using AppQuanLyThuHocPhi.Service;
using AppQuanLyThuHocPhi.Web.App_Start;
using AppQuanLyThuHocPhi.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppQuanLyThuHocPhi.Web.Controllers
{
    public class LopController : BaseController
    {
        private ILopService _LopRepo;
        public LopController(ILopService LopRepo)
        {
            _LopRepo = LopRepo;

        }
        public ActionResult Index()
        {
            var model = _LopRepo.GETALL();
            var modelVm = MappingConfig.Mapper.Map<IEnumerable<Lop>, IEnumerable<LopViewModel>>(model);
            return View(modelVm);
        }
    }
}