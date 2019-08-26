using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Core;

namespace TinTucCTSV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    //Tạo và phân quyền cho người dùng
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var configuration = services.GetRequiredService<IConfiguration>();
                    AuthorizeSeed.CreateRoles(serviceProvider, configuration).Wait();
                    //Tạo csdl mẫu khi chạy nếu csdl = null
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                    DbContextSeed.Seed(services);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Loi trong run vui long xem lai thong tin .");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
