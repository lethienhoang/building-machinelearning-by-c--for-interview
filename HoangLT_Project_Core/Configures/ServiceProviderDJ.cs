using HoangLT_Project_Core.IServices;
using HoangLT_Project_Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoangLT_Project_Core.Configures
{
    public class ServiceProviderDJ : IServiceProvider
    {
      
        public Microsoft.Extensions.DependencyInjection.ServiceProvider InitServices()
        {
            Microsoft.Extensions.DependencyInjection.ServiceProvider serviceProvider = new ServiceCollection()
                 .AddSingleton<ILinearRegression, LinearRegression>()
                 .AddSingleton<ICurrencyService, CurrencyService>()
                 .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
