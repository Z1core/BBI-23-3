using System;

public class Number
{
    protected int RealPart;

    public Number(int realPart)
    {
        RealPart = realPart;
    }

    public static Number Add(Number num1, Number num2)
    {
        return new Number(num1.RealPart + num2.RealPart);
    }

    public static Number Subtract(Number num1, Number num2)
    {
        return new Number(num1.RealPart - num2.RealPart);
    }

    public static Number Multiply(Number num1, Number num2)
    {
        return new Number(num1.RealPart * num2.RealPart);
    }

    public static Number Divide(Number num1, Number num2)
    {
        if (num2.RealPart == 0)
        {
            Console.WriteLine("Деление на ноль недопустимо.");
            return num1;
        }

        return new Number(num1.RealPart / num2.RealPart);
    }

    public virtual void Print()
    {
        Console.WriteLine($"Number = {RealPart}");
    }
}

public class ComplexNumber : Number
{
    private int ImaginaryPart;

    public ComplexNumber(int realPart, int imaginaryPart) : base(realPart)
    {
        ImaginaryPart = imaginaryPart;
    }

    public static ComplexNumber Add(ComplexNumber num1, ComplexNumber num2)
    {
        return new ComplexNumber(num1.RealPart + num2.RealPart, num1.ImaginaryPart + num2.ImaginaryPart);
    }

    public static ComplexNumber Subtract(ComplexNumber num1, ComplexNumber num2)
    {
        return new ComplexNumber(num1.RealPart - num2.RealPart, num1.ImaginaryPart - num2.ImaginaryPart);
    }

    public static ComplexNumber Multiply(ComplexNumber num1, ComplexNumber num2)
    {
        int realPart = num1.RealPart * num2.RealPart - num1.ImaginaryPart * num2.ImaginaryPart;
        int imaginaryPart = num1.RealPart * num2.ImaginaryPart + num1.ImaginaryPart * num2.RealPart;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public static ComplexNumber Divide(ComplexNumber num1, ComplexNumber num2)
    {
        if (num2.RealPart == 0 && num2.ImaginaryPart == 0)
        {
            Console.WriteLine("Деление на ноль недопустимо.");
            return num1;
        }

        int realPart = (num1.RealPart * num2.RealPart + num1.ImaginaryPart * num2.ImaginaryPart) /
                       (num2.RealPart * num2.RealPart + num2.ImaginaryPart * num2.ImaginaryPart);
        int imaginaryPart = (num1.ImaginaryPart * num2.RealPart - num1.RealPart * num2.ImaginaryPart) /
                            (num2.RealPart * num2.RealPart + num2.ImaginaryPart * num2.ImaginaryPart);
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public override void Print()
    {
        Console.WriteLine($"Number = {RealPart} + {ImaginaryPart}i");
    }
}

public class CWTask2
{
    public static void Main()
    {
        ComplexNumber num1 = new ComplexNumber(5, 4);
        ComplexNumber num2 = new ComplexNumber(3, -2);

        ComplexNumber sum = ComplexNumber.Add(num1, num2);
        ComplexNumber difference = ComplexNumber.Subtract(num1, num2);
        ComplexNumber product = ComplexNumber.Multiply(num1, num2);
        ComplexNumber quotient = ComplexNumber.Divide(num1, num2);

        num1.Print();
        num2.Print();
        sum.Print();
        difference.Print();
        product.Print();
        quotient.Print();
    }
}