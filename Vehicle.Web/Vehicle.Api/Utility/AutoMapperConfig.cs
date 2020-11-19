using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.Bussiness.Models;
using Vehicle.Data;

namespace Vehicle.Api.Utility
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<CategoryViewModel, Category>()
                                    .ForMember(x => x.kindOfName, y => y.MapFrom(z => z.Name));
                config.CreateMap<CustomerViewModel, Customer>();
            });
        }

    }
}