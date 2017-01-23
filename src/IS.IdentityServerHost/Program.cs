using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.IdentityServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //日志组件
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .LiterateConsole(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                .CreateLogger();

            //搭载服务
            using (WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.WriteLine("server runing...");
                Console.ReadLine();
            }
        }
    }
}
