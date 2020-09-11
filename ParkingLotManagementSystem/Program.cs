// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using ParkingLotBussinessLayer;
    using ParkingLotModelLayer;

    /// <summary>
    /// program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main class.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main(string[] args)
        {
         // Receiver.ReceiveFromQueue();
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Builder.
        /// </summary>
        /// <param name="args">args.</param>
        /// <returns>ihostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
