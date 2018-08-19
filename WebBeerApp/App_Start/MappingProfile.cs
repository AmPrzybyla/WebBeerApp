﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBeerApp.Dtos;
using WebBeerApp.Models;

namespace WebBeerApp.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Beer, BeerDto>();

            Mapper.CreateMap<BeerDto, Beer>()
                .ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}