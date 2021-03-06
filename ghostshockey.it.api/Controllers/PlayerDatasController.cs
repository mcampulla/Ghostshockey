﻿using System.Linq;
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
    public class PlayerDatasController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetPlayerDatas()
        {
            return Ok(_ctx.PlayerDatas);
        }

        public IHttpActionResult GetPlayerData([FromODataUri]int key)
        {
            var model = _ctx.PlayerDatas.FirstOrDefault(p => p.PlayerDataID == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }

        public IHttpActionResult Post(PlayerData model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.PlayerDatas.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, PlayerData model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.PlayerDatas.FirstOrDefault(p => p.PlayerDataID == key);
            if (current == null)
            {
                return NotFound();
            }

            model.PlayerDataID = current.PlayerDataID;

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<PlayerData> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var current = _ctx.PlayerDatas.FirstOrDefault(p => p.PlayerDataID== key);
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
            var current = _ctx.PlayerDatas.FirstOrDefault(p => p.PlayerDataID == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.PlayerDatas.Remove(current);
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