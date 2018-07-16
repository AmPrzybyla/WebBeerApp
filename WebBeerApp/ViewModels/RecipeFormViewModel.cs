using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBeerApp.Models;

namespace WebBeerApp.ViewModels
{
    public class RecipeFormViewModel
    {
        public IEnumerable<StyleType> StyleTypes { get; set; }
        public BeerRecipe BeerRecipe { get; set; }
        public List<Hops> Hops { get; set; }

    }
}