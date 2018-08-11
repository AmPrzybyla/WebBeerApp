using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBeerApp.Models;

namespace WebBeerApp.Controllers.Api
{
    public class BeerController : ApiController
    {
        private ApplicationDbContext _context;

        public BeerController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/beer

        public IHttpActionResult GetBeers()
        {
            var beer = _context.Recipes.Include(b=>b.StyleType).ToList();
            Console.WriteLine("Jestem");
            return Ok(beer);
        }

    }
}
