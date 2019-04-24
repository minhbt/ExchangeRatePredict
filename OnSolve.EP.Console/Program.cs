﻿using System;
using Microsoft.Extensions.DependencyInjection;
using OnSolve.EP.Common.Helpers;
using OnSolve.EP.Resources;
using OnSolve.EP.Services;

namespace OnSolve.EP.Program
{
    internal class MainClass
    {

        private const string FROM_ARG = "from";
        private const string TO_ARG = "to";
        public static void Main(string[] args)
        {
            var arguments = CommandLineParser.Parse(args);

            var from = string.Empty;
            var to = string.Empty;
            //if (arguments.ContainsKey(ResourceManagers.FromAgr))
            //{
            //    from = arguments[ResourceManagers.FromAgr];
            //}

            //if (arguments.ContainsKey(ResourceManagers.ToAgr))
            //{
            //    to = arguments[ResourceManagers.ToAgr];
            //}

            if (arguments.ContainsKey(FROM_ARG))
            {
                from = arguments[FROM_ARG];
            }

            if (arguments.ContainsKey(TO_ARG))
            {
                to = arguments[TO_ARG];
            }


            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                //Console.WriteLine(ResourceManagers.mgs_from_to_arg_missing);
                //return;
                Console.WriteLine("You must provide \"from\" and \"to\" arguments");
                return;
            }

            var targetDate = new DateTime(2017, 1, 15);
            var services = new ServiceCollection();
            var numberOfSamples = 12;
            services.AddExchangePredict(opts =>
            {
                opts.Endpoint = Configuration.EndPoint;
                opts.AppId = Configuration.AppId;
            });
            var sp = services.BuildServiceProvider();
            var predictor = sp.GetService<IExchangeRatePredictService>();
            var result = predictor.PredictAsync(from, to, targetDate, numberOfSamples)
                .GetAwaiter()
                .GetResult();

            Console.WriteLine($"The predicted currency exchange from {from} to {to} for {targetDate.ToString("dd/MM/yyyy")} is {result,0:F3}");
            Console.ReadLine();
        }
    }
}
