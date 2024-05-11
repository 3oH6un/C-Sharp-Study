namespace game_study.ThisIsC_SharpSharp._6_Method.Calculator;

public class Calculator
{
    public static int Plus(int a, int b)
    {
        return a + b;
    }

    public static int Minus(int a, int b)
    {
        return a - b;
    }
}

class MainApp
{
    public static void _Main()
    {
        int result = Calculator.Plus(3, 4);
        Console.WriteLine(result);

        result = Calculator.Minus(17, 5);
        Console.WriteLine(result);
    }
}