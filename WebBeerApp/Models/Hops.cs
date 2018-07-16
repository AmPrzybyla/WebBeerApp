﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBeerApp.Models
{
    public class Hops
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public double AlfaAcid { get; set; }

        public int TimeOfBoiling { get; set; }
    }
}