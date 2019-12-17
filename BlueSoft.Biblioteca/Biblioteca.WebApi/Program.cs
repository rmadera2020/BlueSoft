using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Biblioteca.WebApi.Data;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Biblioteca.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var logger4 = LogManager.GetLogger(typeof(Program));


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    logger4.Warn("creating the DB. ! " + DateTime.Now.ToString());
                    var context = services.GetRequiredService<BibliotecaDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    logger4.Error("An error occurred creating the DB. ! " + DateTime.Now.ToString());
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                    
                }
            }

            host.Run();            
            logger4.Info("Inicio Satisfactorio del Servicio ! " + DateTime.Now.ToString() );

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
