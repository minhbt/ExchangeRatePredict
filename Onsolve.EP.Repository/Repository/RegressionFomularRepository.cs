using System.Collections.Generic;
using OnSolve.EP.Models.Business;
//using OnSolve.EP.Models.DTO;
namespace OnSolve.EP.Repositories
{
    public class RegressionFomularRepository: IRegressionFomularRepository
    {
        public RegressionFomularRepository()
        {
        }

        public RegressionFomularBO Create(List<DataPoint2dBO> samples)
        {
            decimal sumX = 0m;
            decimal sumY = 0m;
            decimal sumXY = 0m;
            decimal sumXX = 0m;
            decimal n = samples.Count;

            for (var i = 0; i < n; i++)
            {
                var item = samples[i];

                var x = item.X;
                var y = item.Y;
                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumXX += x * x;
            }

            var slope = ((n * sumXY) - (sumX * sumY)) / ((n * sumXX) - (sumX * sumX));
            var intercept = (sumY - (slope * sumX)) / n;

            return new RegressionFomularBO(slope, intercept);
        }
    }
}
