using System;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> fracs = new List<Fraction> // make a list of each new fraction
        {
            new Fraction(),
            new Fraction(5),
            new Fraction(3,4),
            new Fraction(1,3),
            new Fraction(9,21)
        };

        foreach( Fraction f in fracs)
        {
            Console.WriteLine(f.GetDecimalValue()); // write each fraction to the console in 2 different formats
            Console.WriteLine(f.GetFractionString());
        }
    }
}