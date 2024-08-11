using EIMS.Core.ViewModel.OperationModule;
using EIMS.Service.Manager.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EIMS.App.Controllers.Api.OperationModule
{
    public class GeneralInformationsController : ApiController
    {

        GeneralInformationService _service = new GeneralInformationService();

        [Route("api/GeneralInformations/GetEmployeId")]
        [HttpGet]
        public IHttpActionResult GetEmployeId()
        {
            try
            {
                var code = _service.GenerateEmployeId();
                return Ok(code);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }


        [Route("api/GeneralInformations/GetEmployeInfo")]
        [HttpGet]
        public IHttpActionResult GetEmployeInfo(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.Id == id);
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }

        [Route("api/GeneralInformations/EmployeSearch")]
        [HttpGet]
        public IHttpActionResult EmployeSearch(string query)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.EmployeId.ToLower().Contains(query));
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }

        [Route("api/GeneralInformations/EmployeInfoAutoComplete")]
        [HttpGet]
        public IHttpActionResult EmployeInfoAutoComplete(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .SingleOrDefault(c => c.Id == id);
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }

        // GET: api/GeneralInformations
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/GeneralInformations/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/GeneralInformations
        public IHttpActionResult Post([FromBody]GeneralInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Add(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/GeneralInformations/5
        public IHttpActionResult Put(int id, [FromBody]GeneralInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Update(id, vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/GeneralInformations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Remove(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
