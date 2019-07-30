using HoangLT_Project_Core.Configures;
using HoangLT_Project_Core.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoangLT_Project_Core.Test
{
    [TestClass]
    public class LinearRegressionTest
    {
        public static double tolerance = 1.0e-6;
        public static double[] mock_arr = { 1.0, 2.0, 2.0, 3.0, 4.0, 7.0, 9.0 };
        public static double[] mock_x = { 60.0, 61.0, 62.0, 63.0, 65.0 };
        public static double[] mock_y = { 3.1, 3.6, 3.8, 4.0, 4.1 };


        private static ServiceProvider serviceProvider;
        private static ILinearRegression linearRegression;

        public LinearRegressionTest()
        {
            //Configure DI
            ServiceProviderDJ intstant = new ServiceProviderDJ();
            serviceProvider = intstant.InitServices();

            linearRegression = serviceProvider.GetService<ILinearRegression>();
        }

        [TestMethod]
        public void SumOfArray_NullArray()
        {
            double[] x = null;
            double expected = 0.0;
            double actual = linearRegression.SumOfArray(x);

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void SumOfArray_EmptyArray()
        {
            double[] x = { };
            double expected = 0.0;
            double actual = linearRegression.SumOfArray(x);

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void SumOfArray_Success()
        {
            double[] x = mock_arr;
            double expected = 28.0;
            double actual = linearRegression.SumOfArray(x);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intercept_NullArray_X()
        {
            double[] x = null;
            double[] y = mock_arr;
            double expected = 0.0;
            double actual = linearRegression.Intercept(x, y);

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void Intercept_NullArray_Y()
        {
            double[] x = mock_arr;
            double[] y = null;
            double expected = 0.0;
            double actual = linearRegression.Intercept(x, y);

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void Intercept_EmptyArray_X()
        {
            double[] x = { };
            double[] y = mock_arr;
            double expected = 0.0;
            double actual = linearRegression.Intercept(x, y);

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void Intercept_EmptyArray_Y()
        {
            double[] x = mock_arr;
            double[] y = { };
            double expected = 0.0;
            double actual = linearRegression.Intercept(x, y);

            Assert.AreEqual(expected, actual, tolerance);
        }


        [TestMethod]
        public void Intercept_Success()
        {
            double[] x = mock_x;
            double[] y = mock_y;
            double expected = -7.964;
            double actual = linearRegression.Intercept(x, y);
            actual = Math.Round(actual, 3);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SumOfSquares_EmptyArray()
        {

            double[] x = { };
            double expected = 0.0;
            double actual = linearRegression.SumOfSquares(x);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SumOfSquares_NullArray()
        {

            double[] x = null;
            double expected = 0.0;
            double actual = linearRegression.SumOfSquares(x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumOfSquares_Success()
        {
            
            double[] x = mock_x;
            double expected = 74;
            double actual = linearRegression.SumOfSquares(x);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Correlation_EmptyArray()
        {
            //13.9

            double[] x = mock_x;
            double[] y = { };
            double expected = 0.0;
            double actual = linearRegression.Correlation(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Correlation_NullArray()
        {
            //13.9

            double[] x = null;
            double[] y = mock_y;
            double expected = 0.0;
            double actual = linearRegression.Correlation(x, y);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Correlation_Success()
        {
            //13.9

            double[] x = mock_x;
            double[] y = mock_y;
            double expected = 13.9;
            double actual = linearRegression.Correlation(x, y);
            actual = Math.Round(actual, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Slope_Success()
        {
            //0.18784
            double[] x = mock_x;
            double[] y = mock_y;
            double expected = 0.18784;
            double actual = linearRegression.Slope(x, y);
            actual = Math.Round(actual, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Slope_EmptyArray()
        {
            //0.18784
            double[] x = { };
            double[] y = mock_y;
            double expected = 0.0;
            double actual = linearRegression.Slope(x, y);
            actual = Math.Round(actual, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Slope_NullArray()
        {
            //0.18784
            double[] x = null;
            double[] y = mock_y;
            double expected = 0.0;
            double actual = linearRegression.Slope(x, y);
            actual = Math.Round(actual, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
