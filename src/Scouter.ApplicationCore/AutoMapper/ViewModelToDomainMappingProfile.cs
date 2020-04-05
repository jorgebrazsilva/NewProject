using AutoMapper;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<LevelViewModel, Level>();
            CreateMap<PositionViewModel, Position>();
        }
    }
}
