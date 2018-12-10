using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;

namespace IdentityServer.Data
{
    public class SeedDataBase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "admin@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Admin"
                };
                var result = userManager.CreateAsync(user, "Root@@123").Result;
                if (!result.Succeeded)
                {
                        throw new Exception(result.Errors.First().Description);
                }
            }
        }
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    /*using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {*/
        //        /*var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        //        context.Database.Migrate();

        //        context.Database.EnsureCreated();*/

        //        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        //        var userMgr = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        context.Database.EnsureCreated();

        //        //var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        var alice = userMgr.FindByNameAsync("alice").Result;
        //        if (alice == null)
        //        {
        //            alice = new ApplicationUser
        //            {
        //                UserName = "alice",
        //                Email = "AliceSmith@email.com",
        //                SecurityStamp = Guid.NewGuid().ToString(),
        //            };
        //            var result = userMgr.CreateAsync(alice, "Pass123$").Result;
        //            if (!result.Succeeded)
        //            {
        //                throw new Exception(result.Errors.First().Description);
        //            }

        //            result = userMgr.AddClaimsAsync(alice, new Claim[]{
        //                new Claim(JwtClaimTypes.Name, "Alice Smith"),
        //                new Claim(JwtClaimTypes.GivenName, "Alice"),
        //                new Claim(JwtClaimTypes.FamilyName, "Smith"),
        //                new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
        //                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
        //                new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
        //                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
        //            }).Result;
        //            if (!result.Succeeded)
        //            {
        //                throw new Exception(result.Errors.First().Description);
        //            }
        //            Console.WriteLine("alice created");
        //        }
        //        else
        //        {
        //            Console.WriteLine("alice already exists");
        //        }

        //        var bob = userMgr.FindByNameAsync("bob").Result;
        //        if (bob == null)
        //        {
        //            bob = new ApplicationUser
        //            {
        //                UserName = "bob",
        //                Email = "BobSmith@email.com",
        //                SecurityStamp = Guid.NewGuid().ToString(),
        //            };
        //            var result = userMgr.CreateAsync(bob, "Pass123$").Result;
        //            if (!result.Succeeded)
        //            {
        //                throw new Exception(result.Errors.First().Description);
        //            }

        //            result = userMgr.AddClaimsAsync(bob, new Claim[]{
        //                new Claim(JwtClaimTypes.Name, "Bob Smith"),
        //                new Claim(JwtClaimTypes.GivenName, "Bob"),
        //                new Claim(JwtClaimTypes.FamilyName, "Smith"),
        //                new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
        //                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
        //                new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
        //                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
        //                new Claim("location", "somewhere")
        //            }).Result;
        //            if (!result.Succeeded)
        //            {
        //                throw new Exception(result.Errors.First().Description);
        //            }
        //            Console.WriteLine("bob created");
        //        }
        //        else
        //        {
        //            Console.WriteLine("bob already exists");
        //        }
        //    /*}*/

        //}
    }
}
