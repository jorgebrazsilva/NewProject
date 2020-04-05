using AutoMapper;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Level, LevelViewModel>();
            CreateMap<Position, PositionViewModel>();
        }
    }
}
