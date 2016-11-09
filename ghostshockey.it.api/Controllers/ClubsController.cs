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

        public IHttpActionResult GetClub([FromODataUri]int key)
        {
            var team = _ctx.Clubs.FirstOrDefault(p => p.ClubID == key);

            if (team != null)
                return Ok(team);
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

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

    }
}
