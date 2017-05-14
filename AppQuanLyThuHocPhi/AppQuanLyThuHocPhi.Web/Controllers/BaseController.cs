using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppQuanLyThuHocPhi.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly NLog.ILogger _log = NLog.LogManager.GetCurrentClassLogger();
        protected List<string> ModelErrors
        {
            get
            {
                if (ModelState.IsValid == false)
                    return new List<string>();

                return ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
            }
        }

        protected void Alert(string message, bool isErorr = false)
        {
            if (isErorr)
                TempData["error"] = message;
            else
                TempData["success"] = message;
        }
    }
}