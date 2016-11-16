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
    public class TournamentsController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetTournaments()
        {
            return Ok(_ctx.Tournaments);
        }

        public IHttpActionResult GetTournament([FromODataUri]int key)
        {
            var model = _ctx.Tournaments.FirstOrDefault(p => p.TournamentID == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }

        public IHttpActionResult Post(Tournament model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Tournaments.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, Tournament model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Tournaments.FirstOrDefault(p => p.TournamentID == key);
            if (current == null)
            {
                return NotFound();
            }

            model.TournamentID = current.TournamentID;

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Tournament> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Tournaments.FirstOrDefault(p => p.TournamentID== key);
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
            var current = _ctx.Tournaments.FirstOrDefault(p => p.TournamentID == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.Tournaments.Remove(current);
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