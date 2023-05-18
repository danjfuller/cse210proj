using System;

class Fraction
{
    private int _top;
    private int _bottom;

    // construct fraction with 3 different options
    public Fraction()
    {
        // default is 1/1 = 1
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}"; // return a nice fraction format
    }

    public double GetDecimalValue()
    {
        return _top * 1.0 / _bottom; // the * 1.0 turns this into a double
    }
}