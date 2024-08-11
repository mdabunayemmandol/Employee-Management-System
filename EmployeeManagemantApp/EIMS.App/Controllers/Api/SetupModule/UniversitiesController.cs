using EIMS.Core.ViewModel.SetupModule;
using EIMS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EIMS.App.Controllers.Api.SetupModule
{
    public class UniversitiesController : ApiController
    {
        private UniversityService _service = new UniversityService();
        // GET: api/Universities
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll().ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Universities/5
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

        // POST: api/Universities
        public IHttpActionResult Post([FromBody]UniversityViewModel vm)
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

        // PUT: api/Universities/5
        public IHttpActionResult Put(int id, [FromBody]UniversityViewModel vm)
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

        // DELETE: api/Universities/5
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
