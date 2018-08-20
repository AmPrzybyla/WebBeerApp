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
            var beer = _context.Beer.GroupJoin(_context.Hopses, b => b.Id, h => h.BeerId,(ber, hop)=>new BeerDto {
                Hops =hop.ToList(),
                Name =ber.Name,
                Id=ber.Id,
                StyleType=ber.StyleType,
                StyleTypeId=ber.StyleTypeId
            });
            //var beerDtos = _context.Beer.Include(b => b.StyleType).ToList().Select(Mapper.Map<Beer, BeerDto>);
           
            return Ok(beer);

            //return _context.Beer.ToList();

        }


        public IHttpActionResult GetBeer(int id)
        {
            var beer = _context.Beer.GroupJoin(_context.Hopses, b => b.Id, h => h.BeerId, (ber, hop) => new BeerDto
            {
                Hops = hop.ToList(),
                Name = ber.Name,
                Id = ber.Id,
                StyleType = ber.StyleType,
                StyleTypeId = ber.StyleTypeId
            }).SingleOrDefault(b=>b.Id==id);
          //  var beer = _context.Beer.SingleOrDefault(b => b.Id == id);
            
            if (!ModelState.IsValid)
                return NotFound();


            return Ok(beer);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBeer(int id)
        {
            var hopsInDb = _context.Hopses.Where(h => h.BeerId == id).ToList();
            foreach (var hop in hopsInDb)
            {
                _context.Hopses.Remove(hop);
            }

            var beerInDb = _context.Beer.SingleOrDefault(b => b.Id == id);
            if (beerInDb == null)
                return NotFound();

            _context.Beer.Remove(beerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
