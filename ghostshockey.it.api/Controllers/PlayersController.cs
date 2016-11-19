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
using System.Web.Http.Cors;

namespace ghostshockey.it.api.Controllers
{
    //[MobileAppController]
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlayersController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetPlayers()
        {
            return Ok(_ctx.Players);
        }

        public IHttpActionResult GetPlayer([FromODataUri]int key)
        {
            var model = _ctx.Players.FirstOrDefault(p => p.PlayerID == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }

        public IHttpActionResult Post(Player model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Players.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, Player model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Players.FirstOrDefault(p => p.PlayerID == key);
            if (current == null)
            {
                return NotFound();
            }

            model.PlayerID = current.PlayerID;

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Player> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Players.FirstOrDefault(p => p.PlayerID== key);
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
            var current = _ctx.Players.FirstOrDefault(p => p.PlayerID == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.Players.Remove(current);
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