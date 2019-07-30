using HoangLT_Project_Core.Configs;
using HoangLT_Project_Core.Configures;
using HoangLT_Project_Core.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.Test
{
    [TestClass]
    public class CurrencyServiceTest
    {
        private static ServiceProvider serviceProvider;
        private static ICurrencyService currencyService;
        public CurrencyServiceTest()
        {
            //Configure DI
            ServiceProviderDJ intstant = new ServiceProviderDJ();
            serviceProvider = intstant.InitServices();

            currencyService = serviceProvider.GetService<ICurrencyService>();
        }

        [TestMethod]
        public async Task Get_CheckResultNull()
        {
            string url = "https://www.easycalculation.com/statistics/learn-regression.php";
            var expected = await currencyService.Get(url, "GET");
            
            Assert.AreEqual(expected, null);
        }


        [TestMethod]
        public async Task Get_CheckHasData()
        {
            var date = new DateTime(2017, 10, 15);
            string url = string.Format(EnviromentConfigs.API, date.ToString("yyyy-MM-dd"), EnviromentConfigs.APP_ID, "USD", "VND");
            var expected = await currencyService.Get(url, "GET");

            Assert.AreNotEqual(expected, null);
        }

        [TestMethod]
        public async Task QueryAndBindData_CheckHasData()
        {
            var expected = await currencyService.QueryAndBindData(2017, "USD", "VND");

            Assert.AreNotEqual(expected.Count, 0);
        }

        [TestMethod]
        public async Task QueryAndBindData_CheckNoData()
        {
            var expected = await currencyService.QueryAndBindData(2017, "USD1", "VND");

            Assert.AreEqual(expected.Count, 0);
        }
    }
}
