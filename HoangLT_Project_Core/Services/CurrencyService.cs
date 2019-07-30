using HoangLT_Project_Core.Commons;
using HoangLT_Project_Core.Configs;
using HoangLT_Project_Core.IServices;
using HoangLT_Project_Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<Currency> Get(string url, string datetime)
        {
            try
            {
                var json = await CommonService.ConnectToAPI(url, "GET");

                var obj = JsonConvert.DeserializeObject<Currency>(json);

                return obj;
            }
            catch(Exception)
            {
                return null;
            }
           
        }

        public async Task<List<double>> QueryAndBindData(int year, string currencyFrom, string currencyTo)
        {
            var results = new List<double>();
            
            // GET data in 12 months
            for(int month = 1; month <= 12; month++)
            {
                var date = new DateTime(year, month, 15);
                string url = string.Format(EnviromentConfigs.API, date.ToString("yyyy-MM-dd"), EnviromentConfigs.APP_ID, currencyFrom, currencyTo);
                var result = await this.Get(url, date.ToString("yyyy-mm-dd"));
                if (result != null)
                {
                    var value = result.rates.GetPropValue<double>(currencyTo);
                    results.Add(value);
                }
              
            }
            return results;
        }

     
    }
}
