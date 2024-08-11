using EIMS.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class UniversitiesController : Controller
    {
        // GET: Universities
        public ActionResult UniversitiesCreate(int? id)
        {
            var isActive = new UniversityViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}