namespace StartC_Sharp10.page_3;

public class Final
{
    public static void _Main(string[] args)
    {
        int sum = 0;

        for (int n = 1; n < 1000; n++)
        {
            if (n % 3 != 0 && n % 5 != 0) continue;

            sum += n;
        }

        Console.WriteLine("sum :" + sum);
    }
}