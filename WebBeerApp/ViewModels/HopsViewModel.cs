using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBeerApp.Models;

namespace WebBeerApp.ViewModels
{
    public class HopsViewModel
    {
        public IEnumerable<Hops> Hopses { get; set; }
        public BeerRecipe BeerRecipe { get; set; }
    }
}