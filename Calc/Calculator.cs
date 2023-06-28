namespace Calc
{
    public class Calculator
    {
        public double value1 { get; set; }
        public double value2 { get; set; }
        public double result { get; set; }
    }

    public class AddCalculator: Calculator
    { 
        public AddCalculator (double val1 = 0, double val2 = 0)
        {
            value1 = val1; value2 = val2;
            result = val1 + val2;
        }
    }
    public class SubCalculator : Calculator
    {       
        public SubCalculator(double val1 = 0, double val2 = 0)
        {
            value1 = val1; value2 = val2;
            result = val1 - val2;
        }
    }
    public class MultCalculator : Calculator
    {
        public MultCalculator(double val1 = 0, double val2 = 0)
        {
            value1 = val1; value2 = val2;
            result = val1 * val2;
        }
    }
    public class DivCalculator : Calculator
    {
        public DivCalculator(double val1 = 0, double val2 = 0)
        {
            value1 = val1;
            value2 = val2;
            if (value2 != 0)
                result = val1 / val2;
            else result = double.PositiveInfinity;
        }
    }
    public class ExCalculator: Calculator
    {
        public ExCalculator(double val1 = 0, double val2 = 0)
        {
            value1 = val1;
            value2 = val2;
            result = Math.Pow(val1, val2);
        }
    }
}
