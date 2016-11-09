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
            var person = _ctx.Years.FirstOrDefault(p => p.YearID == key);

            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }

        //[HttpGet]
        //[ODataRoute("Years({key})/Cazzi")]
        //public IHttpActionResult GetMyAss([FromODataUri]int key)
        //{
        //    var person = _ctx.Categories;

        //    if (person != null)
        //        return Ok(person);
        //    else
        //        return NotFound();
        //}

        ////[HttpGet, Route("years")]
        //public IHttpActionResult GetYears()
        //{
        //    try
        //    {
        //        return Ok(_ctx.Years);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        //[HttpGet, Route("years/{key}")]
        //public IHttpActionResult GetYears(int key)
        //{
        //    try
        //    {
        //        return Ok(_ctx.Years.FirstOrDefault(i => i.YearID == key ));
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

        //protected override void Initialize(HttpControllerContext controllerContext)
        //{
        //    base.Initialize(controllerContext);
        //    GhostsDbContext context = new GhostsDbContext();
        //    DomainManager = new EntityDomainManager<Year>(context, Request);
        //}

        //// GET tables/TodoItem
        //public IQueryable<Year> Get()
        //{
        //    using (var ctx = new GhostsDbContext())
        //    {
        //        var y = ctx.Years;
        //    }

        //    return Query();
        //}

        //// GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public SingleResult<Year> GetYear(string id)
        //{
        //    return Lookup(id);
        //}

        //// PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public Task<Year> PatchYear(string id, Delta<Year> patch)
        //{
        //    return UpdateAsync(id, patch);
        //}

        //// POST tables/TodoItem
        //public async Task<IHttpActionResult> PostYear(Year item)
        //{
        //    Year current = await InsertAsync(item);
        //    return CreatedAtRoute("Tables", new { id = current.Id }, current);
        //}

        //// DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public Task DeleteYear(string id)
        //{
        //    return DeleteAsync(id);
        //}
    }
}