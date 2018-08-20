using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBeerApp.Models;

namespace WebBeerApp.ViewModels
{
    public class AddHopViewModel
    {

        public Beer Beer { get; set; }
        //public Hops Hops { get; set; }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }


        public int Weight { get; set; }


        public double AlfaAcid { get; set; }

        public int TimeOfBoiling { get; set; }

        public int BeerId { get; set; }

        public AddHopViewModel()
        {
            Id = 0;
        }

        public AddHopViewModel(Hop hop)
        {
            Id = hop.Id;
            Name = hop.Name;
            Weight = hop.Weight;
            AlfaAcid = hop.AlfaAcid;
            TimeOfBoiling = hop.TimeOfBoiling;
            BeerId = hop.BeerId;
        }
    }

}