using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using WebBeerApp.Models;
using WebBeerApp.Dtos;
using System.Net;
using System.Net.Http;
using AutoMapper;
namespace WebBeerApp.Controllers.Api
{
    public class HopController : ApiController
    {
        private ApplicationDbContext _context;

        public HopController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetHops()
        {
            var hopDtos = _context.Hopses.ToList().Select(Mapper.Map<Hop, HopDto>);
            return Ok(hopDtos);

            //return _context.Beer.ToList();

        }

        public IHttpActionResult GetHop(int id)
        {
            var hop = _context.Hopses.SingleOrDefault(h => h.Id == id);

            if (!ModelState.IsValid)
                return NotFound();


            return Ok(Mapper.Map<Hop, HopDto>(hop));
        }


        [HttpDelete]
        public IHttpActionResult DeleteHop(int id)
        {

            var hopInDb = _context.Hopses.SingleOrDefault(b => b.Id == id);
            if (hopInDb == null)
                return NotFound();

            _context.Hopses.Remove(hopInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
