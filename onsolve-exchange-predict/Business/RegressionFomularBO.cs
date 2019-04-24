namespace OnSolve.EP.Models.BO
{
    public class RegressionFomularBO
    {
        public RegressionFomularBO(decimal slope, decimal intercept)
        {
            Slope = slope;
            Intercept = intercept;
        }

        public decimal Slope { get; private set; }

        public decimal Intercept { get; private set; }

        public decimal Calculate(decimal x)
        {
            return Intercept + (Slope * x);
        }
    }
}
