namespace ThisIsC_Sharp._Exercise.Ex6_3;

public class MainApp
{
    public static void _Main()
    {
        int a = 3;
        int b = 4;

        Plus(a, b, out int resultA);

        Console.WriteLine("{0} + {1} = {2}", a, b, resultA);

        double x = 2.4;
        double y = 3.1;

        Plus(x, y, out double resultB);

        Console.WriteLine("{0} + {1} = {2}", x, y, resultB);
    }

    public static void Plus(int a, int b, out int c)
    {
        c = a + b;
    }

    public static void Plus(double a, double b, out double c)
    {
        c = a + b;
    }
}