using System;
using HoangLT_Project_Core.Configs;
using HoangLT_Project_Core.Configures;
using HoangLT_Project_Core.IServices;
using HoangLT_Project_Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HoangLT_Project_Core
{
    class Program
    {
        private static ServiceProvider serviceProvider;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Configure DI
            ServiceProviderDJ intstant = new ServiceProviderDJ();
            serviceProvider = intstant.InitServices();

            var linearReg = serviceProvider.GetService<ILinearRegression>();
            var currencyService = serviceProvider.GetService<ICurrencyService>();
            
            int year = 0;

            Console.WriteLine("Please input currency from: ");
            var currencyFrom = Console.ReadLine();

            Console.WriteLine("Please input currency to: ");
            var currencyTo = Console.ReadLine();

 
            Console.WriteLine("Please input Year here: ");            
            int.TryParse(Console.ReadLine(), out year);

            Console.WriteLine("Please waiting for retrive data...");
            var lstRates = await currencyService.QueryAndBindData(year, currencyFrom.ToUpper(), currencyTo.ToUpper());           

            double[] xMonth = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            double[] yRate = new double[13];

            yRate  = lstRates.ToArray();

            if (xMonth.Length != yRate.Length)
            {
                Console.WriteLine("Month values should be with the same length with Rate.");
            }



            // xMonth,yRate are the coordinates of any point on the line
            // a is the slope of the line
            // b is the y - intercept


            var a = linearReg.Slope(xMonth, yRate);
            var b = linearReg.Intercept(xMonth, yRate);

            Console.WriteLine("slope is: " + a);
            Console.WriteLine("Intercept is: " + b);

            for(int i=0; i < xMonth.Length; i++)
            {
                // Slope * month + intercept
                var predictedValue = (a * xMonth[i]) + b;
                Console.WriteLine($"Prediction  currency exchange from {currencyFrom} to {currencyTo} for 15/{xMonth[i]}/{year}: {predictedValue}");
            }
            
        }
    }
}
