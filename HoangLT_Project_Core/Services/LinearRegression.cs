using HoangLT_Project_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.Services
{

    /// <summary>
    /// </summary>
    public class LinearRegression : ILinearRegression
    {

        public double SumOfArray(double[] values)
        {
            double sum = 0.0;
            if ((values != null) && (values.Length > 0))
            {

                for (int i = 0; i < values.Length; i++)
                    sum += values[i];                
            }
            return sum;
        }

        /// <summary>
        /// (NΣXY - (ΣX)(ΣY))
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Correlation(double[] x, double[] y)
        {
            double correlation = 0.0;
            if ((x != null) && (y != null) && (x.Length == y.Length) && (x.Length > 0))
            {
                for (int i = 0; i < x.Length; ++i)
                {
                    correlation += x[i] * y[i];
                }

                correlation *= x.Length;

                double xsum = SumOfArray(x);
                double ysum = SumOfArray(y);
                correlation -= xsum * ysum;
            }
            return correlation;
        }

        /// <summary>
        /// (ΣY - b(ΣX)) / N 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Intercept(double[] x, double[] y)
        {
            double intercept = 0.0;
            if ((x != null) && (y != null) && (x.Length == y.Length) && (x.Length > 0))
            {
                double xsum= SumOfArray(x);
                double ysum = SumOfArray(y);
                intercept = (ysum - Slope(x, y) * xsum)/ x.Length;
            }
            return intercept;
        }

        /// <summary>
        /// (NΣXY - (ΣX)(ΣY)) / (NΣX2 - (ΣX)2)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Slope(double[] x, double[] y)
        {
            double slope = 0.0;
            if ((x != null) && (y != null) && (x.Length == y.Length) && (x.Length > 0))
            {
                slope = Correlation(x, y) / SumOfSquares(x); 
            }
            return slope;
        }

        /// <summary>
        /// (NΣX2 - (ΣX)2)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public double SumOfSquares(double[] values)
        {
            double sumOfSquares = 0.0;
            if ((values != null) && (values.Length > 0))
            {
                for(int i = 0; i < values.Length; i++)
                {
                    sumOfSquares += values[i] * values[i];
                }

                double sum = SumOfArray(values);
                sumOfSquares *= values.Length;
                
                sumOfSquares -= sum * sum;

                Console.WriteLine(sumOfSquares + "" + sum);
            }
            return sumOfSquares;
        }
    }
}
