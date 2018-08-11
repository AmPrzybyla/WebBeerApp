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
    }
}