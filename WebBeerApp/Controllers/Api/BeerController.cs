using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBeerApp.Models;
using WebBeerApp.Dtos;
using AutoMapper;

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
            var beerDtos = _context.Beer.Include(b => b.StyleType).ToList().Select(Mapper.Map<Beer, BeerDto>);
            return Ok(beerDtos);

            //return _context.Beer.ToList();

        }


        public IHttpActionResult GetBeer(int id)
        {
            var beer = _context.Beer.SingleOrDefault(b => b.Id == id);

            if (!ModelState.IsValid)
                return NotFound();


            return Ok(Mapper.Map<Beer, BeerDto>(beer));
        }

    }
}
