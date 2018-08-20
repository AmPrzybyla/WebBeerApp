using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBeerApp.Models;

namespace WebBeerApp.Dtos
{
    public class BeerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Style")]
        public int StyleTypeId { get; set; }

        public StyleType StyleType { get; set; }

        public ICollection<Hop> Hops { get; set; }
    }
}