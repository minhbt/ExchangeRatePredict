namespace OnSolve.EP.Models.BO
{
    public class DataPoint2DBO
    {
        public DataPoint2DBO(int x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}
