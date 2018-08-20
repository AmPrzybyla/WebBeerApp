using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBeerApp.Models;

namespace WebBeerApp.ViewModels
{
    public class RecipeViewModel
    {
        public IEnumerable<StyleType> StyleTypes { get; set; }
        public Beer Beer { get; set; }
        public ICollection<Hop> Hops { get; set; }
    }
}