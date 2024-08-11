using EIMS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult DepartmentCreate(int? id)
        {
            var isActive = new DepartmentViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}