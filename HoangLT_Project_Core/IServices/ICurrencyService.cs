using HoangLT_Project_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.IServices
{
    public interface ICurrencyService
    {
        Task<Currency> Get(string url, string datetime);
        Task<List<double>> QueryAndBindData(int year, string currencyFrom, string currencyTo);
    }
}
