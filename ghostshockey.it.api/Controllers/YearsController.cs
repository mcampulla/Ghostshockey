using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.OData;
using Microsoft.Azure.Mobile.Server;
using ghostshockey.it.api.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http.Results;
using System.Web.OData.Routing;
using System.Net;

namespace ghostshockey.it.api.Controllers
{
    //[MobileAppController]
    public class YearsController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetYears()
        {
            return Ok(_ctx.Years.ToList().Select(y => y.MapToDto()));
        }

        public IHttpActionResult GetYear([FromODataUri]int key)
        {
            var person = _ctx.Years.FirstOrDefault(p => p.YearID == key);

            if (person != null)
                return Ok(person.MapToDto());
            else
                return NotFound();
        }

        public IHttpActionResult Post(model.Poco.Year model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Years.Add(model.MapToModel());
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, model.Poco.Year model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Years.FirstOrDefault(p => p.YearID == key);
            if (current == null)
            {
                return NotFound();
            }

            model.YearID = current.YearID;

            _ctx.Entry(current).CurrentValues.SetValues(model.MapToModel());
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<model.Poco.Year> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Years.FirstOrDefault(p => p.YearID== key);
            if (current == null)
            {
                return NotFound();
            }

            //patch.Patch(patch.ma);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var current = _ctx.Years.FirstOrDefault(p => p.YearID == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.Years.Remove(current);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

       
    }
}