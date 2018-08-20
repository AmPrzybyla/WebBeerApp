using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebBeerApp.Models;
using WebBeerApp.ViewModels;

namespace WebBeerApp.Controllers
{
    public class BeerController : Controller
    {

        private ApplicationDbContext _context;

        public BeerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Beer
        public ActionResult Index()
        {
            // var beers = _context.Recipes.Include(b => b.StyleType).ToList();
            //  return View(beers);
            return View();
        }


        public ActionResult New()
        {
            var styleTypes = _context.StyleTypes.ToList();
            var viewModel = new BeerFormViewModel
            {
                Beer = new Beer(),
                StyleTypes= styleTypes
            };
            return View("BeerForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BeerFormViewModel
                {
                    Beer = beer,
                    StyleTypes = _context.StyleTypes.ToList()
                };
                return View("BeerForm", viewModel);
            }

            _context.Beer.Add(beer); 
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult SaveHop (Hop hop)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddHopViewModel();
                return View("BeerForm", viewModel);
            }

            if(hop.Id==0)
            _context.Hopses.Add(hop);

            else
            {
                var hopInDb = _context.Hopses.Single(h => h.Id == hop.Id);
                hopInDb.Name = hop.Name;
                hopInDb.TimeOfBoiling = hop.TimeOfBoiling;
                hopInDb.Weight = hop.Weight;
                hopInDb.AlfaAcid = hop.AlfaAcid;
            }
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var beer = _context.Beer.Include(b => b.StyleType).SingleOrDefault(b => b.Id == id);

            if (beer == null)
                return HttpNotFound();

            var recipe = _context.Hopses.Where(r => r.BeerId == id).ToList();

            var viewModel = new RecipeViewModel
            {
                Beer=beer,
                Hops=recipe,
                StyleTypes=_context.StyleTypes.ToList()
            };
            

            return View(viewModel);
        }




        public ActionResult AddHop(int id)
        {

            var beer = _context.Beer.SingleOrDefault(b => b.Id == id);

            if (!_context.Beer.Any(b => b.Id == id))
            {
                return HttpNotFound();

            }

            var viewModel = new AddHopViewModel
            {
                Beer=beer
            };


            return View(viewModel);
        }


        public ActionResult EditHop(int id)
        {
            var hop = _context.Hopses.SingleOrDefault(h => h.Id == id);
            
            if (hop == null)
                return HttpNotFound();
            var beer = _context.Beer.Single(b => b.Id == hop.BeerId);

            var viewModel = new AddHopViewModel(hop)
            {
                Beer = beer
            };


            return View(viewModel);
        }
    }
}