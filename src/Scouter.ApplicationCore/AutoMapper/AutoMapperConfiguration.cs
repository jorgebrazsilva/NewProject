using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
                mc.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
