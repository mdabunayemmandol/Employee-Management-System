using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIMS.Core.Model;
using EIMS.Core.Model.SetupModule;

namespace EIMS.App.Controllers
{
    public class EducationalInformationsController : Controller
    {
        // GET: EducationalInformations
        public ActionResult EducationalInformationsEntry(int? id)
        {
            ViewBag.UniversityId = new SelectList(new List<University>(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(new List<Subject>(), "Id", "Name");
            return View();
        }
    }
}