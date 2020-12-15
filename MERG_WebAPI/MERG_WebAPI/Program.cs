using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MERG_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
             try
            {
                var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                var str = "select * from RealEstate";
                var command = new MySqlCommand(str, conn);
                conn.Open();
                using (var r = command.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var first = r.GetString(0);
                        var second = r.GetValue(1);
                        var third = r.GetString(2);

                        Console.WriteLine($"{first}  {second} {third}");
                    }
                }
                Console.WriteLine("Pavyko");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "Nepavyko :(");
            }
            CreateHostBuilder(args).Build().Run();

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
