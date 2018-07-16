using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBeerApp.Models
{
    public class BeerRecipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Style")]
        public int StyleTypeId { get; set; }

        public StyleType StyleType { get; set; }

        public List<Hops> Hopses { get; set; }
    }
}