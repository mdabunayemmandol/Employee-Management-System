using EIMS.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult SubjectsCreate(int? id)
        {
            var isActive = new SubjectViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}