using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
namespace Project1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()){
                var provider = scope.ServiceProvider;
                try {
                    //--G: Chỉ lấy được DbContextOptions từ IServiceCollection, inject vào để tạo mới context như đúng ý muốn
                    //-- Trong dbContextOptions có connectionstrings, service để giúp cấu hình Context nói tới.
                    //Dùng xong nhớ Dispose
                    var context = new RazorPagesMovieContext(provider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>());
                    if(!context.Movie.Any()){
                        context.Movie.AddRange(
                            new Movie(){
                                Genre = "Clear",
                                Price = 1000,
                                ReleaseDate = DateTime.Parse("1/1/1111"),
                                Title = "Df"
                            }
                        );
                        context.SaveChanges();
                        context.Dispose();
                    }
                } catch (Exception ex){
                    var logger = provider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error!");
                }
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
