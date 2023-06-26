namespace Calc
{
    public class Calculator
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
        public virtual int result { get; set; }
    }

    public class AddCalculator: Calculator
    {
        public AddCalculator()
        {
            value1 = 0; value2 = 0;
        }
        public AddCalculator (int val1, int val2)
        {
            value1 = val1; value2 = val2;
        }
        override public int result => value1 + value2;
    }
    public class SubCalculator : Calculator
    {
        public SubCalculator()
        {
            value1 = 0; value2 = 0;
        }
        public SubCalculator(int val1, int val2)
        {
            value1 = val1; value2 = val2;
        }
        override public int result => value1 - value2;
    }
    public class MultCalculator : Calculator
    {
        public MultCalculator()
        {
            value1 = 0; value2 = 0;
        }
        public MultCalculator(int val1, int val2)
        {
            value1 = val1; value2 = val2;
        }
        override public int result => value1 * value2;
    }
    public class DivCalculator : Calculator
    {
        public DivCalculator()
        {
            value1 = 0; value2 = -1;
        }
        public DivCalculator(int val1, int val2)
        {
            value1 = val1;
            if (val2 == 0)
            { value1 = 0; value2 = 1; }
            else value2 = val2;
        }
        override public int result => value1 / value2;
    }
}
