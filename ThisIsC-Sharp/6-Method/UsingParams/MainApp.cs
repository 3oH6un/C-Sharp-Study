namespace ThisIsC_Sharp._6_Method.UsingParams;

public class MainApp
{
    static int Sum(params int[] args)
    {
        Console.WriteLine("Summing... ");

        int sum = 0;

        for (int i = 0; i < args.Length; i++)
        {
            if (i > 0)
                Console.Write(", ");

            Console.Write(args[i]);

            sum += args[i];
        }

        Console.WriteLine();

        return sum;
    }

    static void _Main(string[] args)
    {
        int sum = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        Console.WriteLine($"Sum : {sum}");
    }
}