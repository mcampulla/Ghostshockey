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

namespace ghostshockey.it.api.Controllers
{
    public class CategoriesController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        [EnableQuery]
        public IHttpActionResult GetCategories()
        {
            return Ok(_ctx.Categories);
        }

        public IHttpActionResult GetCategory([FromODataUri]int key)
        {
            var person = _ctx.Categories.FirstOrDefault(p => p.CategoryID == key);

            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

    }
}
