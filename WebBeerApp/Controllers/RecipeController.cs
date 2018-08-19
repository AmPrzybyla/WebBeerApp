using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBeerApp.Models;

namespace WebBeerApp.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext _context;

        public RecipeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult NewHop(NewHop newHop, Hops hop)
        //{
        //    var beer = _context.Beer.Single(b => b.Id == newHop.BeerId);

        //    var recipe = new Recipe
        //    {
        //        Beer = beer,
        //        Hops=hop
                

        //    };

        //    _context.Recipes.Add(recipe);
        //    _context.SaveChanges();
        //    return View();
        //}

    }
}