using EIMS.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class DesignationsController : Controller
    {
        // GET: Designations
        public ActionResult DesignationsCreate(int? id)
        {
            var isActive = new DesignationViewModel() { IsActive = true };
            return View();
        }
    }
}