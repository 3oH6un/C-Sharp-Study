namespace ThisIsC_Sharp._6_Method.SwapByValue;

public class MainApp
{
    public static void Swap(int a, int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }

    static void _Main()
    {
        int x = 3;
        int y = 4;

        Console.WriteLine($"x:{x}, y:{y}");

        Swap(x, y);

        Console.WriteLine($"x:{x}, y:{y}");
    }
}