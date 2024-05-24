using System;

public struct Number
{
    public int Real;

    public static Number Add(Number num1, Number num2)
    {
        return new Number { Real = num1.Real + num2.Real };
    }

    public static Number Subtract(Number num1, Number num2)
    {
        return new Number { Real = num1.Real - num2.Real };
    }

    public static Number Multiply(Number num1, Number num2)
    {
        return new Number { Real = num1.Real * num2.Real };
    }

    public static Number Divide(Number num1, Number num2)
    {
        return new Number { Real = num1.Real / num2.Real };
    }

    public static void Display(Number num)
    {
        Console.WriteLine($"Number = {num.Real}");
    }

    public Number(int real)
    {
        Real = real;
    }
}

class Program
{
    static void Main()
    {
        Number num1 = new Number(10);
        Number num2 = new Number(5);

        Number sum = Number.Add(num1, num2);
        Number difference = Number.Subtract(num1, num2);
        Number product = Number.Multiply(num1, num2);
        Number quotient = Number.Divide(num1, num2);

        Number.Display(num1);
        Number.Display(num2);
        Number.Display(sum);
        Number.Display(difference);
        Number.Display(product);
        Number.Display(quotient);
    }
}
