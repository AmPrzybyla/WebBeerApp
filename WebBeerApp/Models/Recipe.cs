using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeerApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public Beer Beer { get; set; }
        public ICollection<Hops> Hops { get; set; }
    }
}