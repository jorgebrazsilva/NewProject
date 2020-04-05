using Microsoft.Extensions.DependencyInjection;
using Scouter.ApplicationCore.AutoMapper;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.ApplicationCore.Services;
using Scouter.Infrastructure.Context;
using Scouter.Infrastructure.Repository;
using Scouter.Infrastructure.UoW;
using Scouter.MessageManager.Interfaces;
using Scouter.MessageManager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterAutoMapper(services);
            RegisterDataRepository(services);
            RegisterService(services);
            RegisterMessages(services);
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            services.AddSingleton(mappingConfig.CreateMapper());
        }

        private static void RegisterDataRepository(IServiceCollection services)
        {
            services.AddScoped<ScouterContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IPositionService, PositionService>();
        }

        private static void RegisterMessages(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, MessageService>();
            services.AddTransient<ISmsSender, MessageService>();
        }
    }
}
