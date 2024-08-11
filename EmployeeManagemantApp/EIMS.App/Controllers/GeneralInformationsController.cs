using EIMS.Core.Model;
using EIMS.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class GeneralInformationsController : Controller
    {
        // GET: GeneralInformations
        public ActionResult EmployeCreate(int? id)
        {
            ViewBag.DepartmentId = new SelectList(new List<Department>(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(new List<Designation>(), "Id", "Name");
            return View();
        }
    }
}