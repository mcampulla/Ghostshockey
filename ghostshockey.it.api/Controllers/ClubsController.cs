using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.OData;
using Microsoft.Azure.Mobile.Server;
using ghostshockey.it.api.Models;
using ghostshockey.it.api.Helpers;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http.Results;
using System.Web.OData.Routing;
using System.Net;

namespace ghostshockey.it.api.Controllers
{
    public class ClubsController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetClubs()
        {
            return Ok(_ctx.Clubs);
        }

        [EnableQuery]
        public IHttpActionResult GetClub([FromODataUri]int key)
        {
            var model = _ctx.Clubs.Where(p => p.ClubID == key);

            if (model.Any())
                return Ok(SingleResult.Create(model));
            else
                return NotFound();
        }

        [HttpGet]
        [ODataRoute("Clubs({key})/Icon")]
        [ODataRoute("Clubs({key})/Tag")]
        public IHttpActionResult GetClubProperty([FromODataUri]int key)
        {
            var club = _ctx.Clubs.FirstOrDefault(p => p.ClubID == key);

            if (club == null)
            {
                return NotFound();
            }

            var propertyToGet = Url.Request.RequestUri.Segments.Last();
            if (!club.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = club.GetValue(propertyToGet);
            if (propertyValue == null)
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            return this.CreateOKHttpActionResult(propertyValue);
        }

        [HttpGet]
        [ODataRoute("Clubs({key})/Teams")]
        public IHttpActionResult GetClubs([FromODataUri]int key)
        {
            var collectionPropertyToGet = Url.Request.RequestUri.Segments.Last();
            var club = _ctx.Clubs.Include(collectionPropertyToGet)
                .FirstOrDefault(p => p.ClubID == key);

            if (club == null)
            {
                return NotFound();
            }

            if (!club.HasProperty(collectionPropertyToGet))
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            var collectionPropertyValue = club.GetValue(collectionPropertyToGet);

            return this.CreateOKHttpActionResult(collectionPropertyValue);
        }


        public IHttpActionResult Post(Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ctx.Categories.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, Club model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Clubs.FirstOrDefault(p => p.ClubID == key);
            if (current == null)
            {
                return NotFound();
            }

            model.ClubID = current.ClubID;

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Club> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Clubs.FirstOrDefault(p => p.ClubID == key);
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
            var current = _ctx.Clubs.FirstOrDefault(p => p.ClubID == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.Clubs.Remove(current);
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
