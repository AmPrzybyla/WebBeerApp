using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
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
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Beer
        public ActionResult Index()
        {

            var beer = _context.Recipes.Include(b => b.StyleType).ToList();

            return View(beer);
        }

        public ActionResult AddHop(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(h => h.Id == id);
            if (recipe == null)
                return HttpNotFound();

            var ViewModel = new RecipeFormViewModel
            {
                BeerRecipe = recipe,
                Hops = _context.Hopses.ToList()

            };
            return View(ViewModel);
        }
    }
}