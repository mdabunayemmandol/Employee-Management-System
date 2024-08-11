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
    public class TrainingInformationsController : ApiController
    {
        private TrainingInformationService _service = new TrainingInformationService();
        [Route("api/TrainingInformations/GetTrainingInfo")]
        [HttpGet]
        public IHttpActionResult GetTrainingInfo(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.GeneralInformationId == id);
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }
        // GET: api/TrainingInformations
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

        // GET: api/TrainingInformations/5
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

        // POST: api/TrainingInformations
        public IHttpActionResult Post([FromBody]TrainingInformationViewModel vm)
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

        // PUT: api/TrainingInformations/5
        public IHttpActionResult Put(int id, [FromBody]TrainingInformationViewModel vm)
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

        // DELETE: api/TrainingInformations/5
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
