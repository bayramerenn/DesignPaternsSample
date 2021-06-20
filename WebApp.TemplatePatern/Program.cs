using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.TemplatePatern.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BaseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            identityDbContext.Database.Migrate();

            if (!userManeger.Users.Any())
            {
                userManeger.CreateAsync(new AppUser() { UserName = "user1", Email = "user1@outlook.com",PictureUrl = "/userpictures/user.png",Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden" }, "Password12*").Wait();     
                userManeger.CreateAsync(new AppUser() { UserName = "user2", Email = "user2@outlook.com",PictureUrl = "/userpictures/user.png",Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden" }, "Password12*").Wait();    
                userManeger.CreateAsync(new AppUser() { UserName = "user3", Email = "user3@outlook.com" ,PictureUrl = "/userpictures/user.png",Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden"}, "Password12*").Wait();    
                userManeger.CreateAsync(new AppUser() { UserName = "user4", Email = "user4@outlook.com",PictureUrl = "/userpictures/user.png",Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden" }, "Password12*").Wait();     
                userManeger.CreateAsync(new AppUser() { UserName = "user5", Email = "user5@outlook.com" ,PictureUrl = "/userpictures/user.png",Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden"}, "Password12*").Wait();    
                
            }

        
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
