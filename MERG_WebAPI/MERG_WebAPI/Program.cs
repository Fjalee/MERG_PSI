using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MERG_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
             try
            {
                var con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
                var str = "select * from realestate";
                var command = new MySqlCommand(str, con);
                con.Open();
                using (var r = command.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var first = r.GetString(0);
                        var second = r.GetValue(1);

                        Console.WriteLine($"{first}  {second}");

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
