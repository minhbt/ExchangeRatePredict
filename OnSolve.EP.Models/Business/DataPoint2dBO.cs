using System;
namespace OnSolve.EP.Models.Business
{
    public class DataPoint2dBO
    {
        public DataPoint2dBO(int x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}
