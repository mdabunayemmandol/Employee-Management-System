using EIMS.Service.Manager.ReportModule;
using Microsoft.Reporting.WebForms;
using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace EIMS.App.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService = new ReportService();

        // GET: Report
        public ActionResult AllReport()
        {
            return View();
        }



        [HttpPost]
        [Route("Report/GetAllEmployee")]
        public JsonResult GetAllEmployee()
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Reports"), "AllEmployeeList.rdlc");
                viewer.LocalReport.ReportPath = path;

                var userInfo = _reportService.GetAll();
                var ci = new ReportDataSource("EmployeeDataset", userInfo);
                viewer.LocalReport.DataSources.Add(ci);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = "EmployeeReport_" + DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Reports";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Reports/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




    }
}