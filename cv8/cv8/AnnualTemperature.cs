using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv8
{
    public class AnnualTemperature
    {
        public int Year { get; }
        public List<double> MonthlyTemperatures { get; }

        public AnnualTemperature(int year, List<double> monthlyTemperatures)
        {
            Year = year;
            MonthlyTemperatures = monthlyTemperatures ?? new List<double>();
        }

        public double MaxTemperature => MonthlyTemperatures.Max();

        public double MinTemperature => MonthlyTemperatures.Min();

        public double AverageYearlyTemperature => MonthlyTemperatures.Average();
    }

}
