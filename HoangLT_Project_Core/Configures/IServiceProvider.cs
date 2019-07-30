using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoangLT_Project_Core.Configures
{
    public interface IServiceProvider
    {
        Microsoft.Extensions.DependencyInjection.ServiceProvider InitServices();
    }
}
