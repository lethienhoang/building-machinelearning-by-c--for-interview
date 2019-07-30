using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.IServices
{
    public interface ILinearRegression 
    {
        double Slope(double[] x, double[] y);


        double Intercept(double[] x, double[] y);


        double SumOfArray(double[] values);
       

        double SumOfSquares(double[] values);
     

        double Correlation(double[] x, double[] y);
       
    }
}
