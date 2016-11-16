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
            return Ok(_ctx.Years);
        }

        public IHttpActionResult GetYear([FromODataUri]int key)
        {
            var model = _ctx.Years.FirstOrDefault(p => p.YearID == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }

        public IHttpActionResult Post(Year model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Years.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, Year model)
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

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Year> patch)
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

            patch.Patch(current);
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