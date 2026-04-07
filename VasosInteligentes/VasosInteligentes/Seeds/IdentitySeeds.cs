
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.IO;
using VasosInteligentes.Models;
namespace VasosInteligentes.Seeds
{
    public class IdentitySeeds
    {
         public static async Task SeedRolesAndUser(
             IServiceProvider serviceProvider, string defaultPassword, object roleName)
         {
            //Criação das roles (Admin e Usuário)
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            string[] rolesNames = { "Administrador", "Usuario" };
            foreach (var roleNames in rolesNames)
            {
                //verificar se já foi criado
                if(await roleManager.FindByNameAsync(roleNames) == null)
                {
                    //Se não encontrou será inserido
                    var result = await roleManager.CreateAsync(
                        new ApplicationRole { Name = roleNames }
                     );
                    if (result.Succeeded)
                    {
                        Console.WriteLine($"SEED: Role {roleName} foi criada");
                    }
                    else { return; }
                }
            }//fim do foreach
             //criar os usuarios
             //criar o administrador
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>> ();
            if (await userManager.FindByEmailAsync("admin@admin.com") == null)
            {
                //Se não encontrou será inserido
                var adminUser = new ApplicationUser
                {
                    Username = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true
                };
                var resultAdmin = await userManager.CreateAsync(adminUser, "admin@admin.com");
                if (resultAdmin.Succeeded)
                {
                    Console.WriteLine($"SEED: Administrador foi criado");
                    await userManager.AddToRoleAsync(adminUser, "Adm");
                }
                else { return; }
            }//Fim do if
            //criar um usuário comum
            if (await userManager.FindByEmailAsync("teste@usuario.com") == null)
            {
                //Se não encontrou será inserido
                var user = new ApplicationUser
                {
                    Username = "teste@usuario.com",
                    Email = "teste@usuario.com",
                    EmailConfirmed = true
                };
                var resultUser = await userManager.CreateAsync(user, "Teste@");
                if (resultUser.Succeeded)
                {
                    Console.WriteLine($"SEED: Administrador foi criado");
                    await userManager.AddToRoleAsync(user, "Usuario");
                }
                else { return; }
            }
        }

        internal static async Task SeedRolesAndUser(IServiceProvider services, string v)
        {
            throw new NotImplementedException();
        }
    }
}
