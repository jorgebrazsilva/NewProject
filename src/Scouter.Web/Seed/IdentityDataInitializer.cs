using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Scouter.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Scouter.ApplicationCore.ViewModels;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.Enumerators;

namespace Scouter.Web.Seed
{
    public class IdentityDataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;

        public IdentityDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUsuarioService usuarioService)
        {
            _context = context;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        public async Task InitializeData()
        {
            await InitializeUserIdentityData("Admin", "admin@gmail.com");           
            await InitializeClaimsData("admin@gmail.com");           
            await InitializeUsuarioData("admin@gmail.com", "Admin Scouter");           
        }

        private async Task InitializeUsuarioData(string email, string nome)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return;

            if (_usuarioService.GetById(Guid.Parse(user.Id)) != null) return;

            var usuario = new UsuarioViewModel
            {
                Id = Guid.Parse(user.Id),
                Nome = nome,
                Email = email,
                Ativo = true,
                Bloqueado = false,
                PerfilName = EnumPerfil.Administrator.ToString()
            };
            _usuarioService.Add(usuario);
        }

        private IEnumerable<Claim> GetAdminClaimsData()
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Administrator")
            };
            return claims;
        }

        private async Task InitializeClaimsData(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var claims = await _userManager.GetClaimsAsync(user);
                if (claims.Any())
                    return;

                await _userManager.AddClaimsAsync(user, GetAdminClaimsData());
                await _context.SaveChangesAsync();
            }
        }

        private async Task InitializeUserIdentityData(string name, string email)
        {
            if (_context.Users.Any(u => u.UserName == name)) return;

            var user = new IdentityUser { UserName = name, Email = email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, "@Admin123");
            if (result.Succeeded)
                await _context.SaveChangesAsync();

        }
    }

    public static class IdentitySeed
    {
        public static async void Seed(IWebHost host)
        {
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var identitySeed = new IdentityDataInitializer(context, services.GetRequiredService<UserManager<IdentityUser>>(),
                        services.GetRequiredService<IUsuarioService>());
                    await identitySeed.InitializeData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while seeding the database.");
            }

        }
    }
}
