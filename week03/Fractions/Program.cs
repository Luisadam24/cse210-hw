using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
    }
    public class Fraction
    {
        private int _top;
        private int _bottom;

        // Constructors
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        // Getters
        public int GetTop()
        {
            return _top;
        }

        public int GetBottom()
        {
            return _bottom;
        }

        // Setters
        public void SetTop(int top)
        {
            _top = top;
        }

        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }

        // Returns the fraction as a string
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Returns the decimal value
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}