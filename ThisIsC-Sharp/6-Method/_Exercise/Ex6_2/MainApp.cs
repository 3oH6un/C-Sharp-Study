namespace ThisIsC_Sharp._Exercise.Ex6_2;

public class MainApp
{
    public static void _Main()
    {
        Mean(1, 2, 3, 4, 5, out double mean);

        Console.WriteLine("평균 : {0}", mean);
    }

    public static void Mean(
        double a, double b, double c,
        double d, double e, out double mean)
    {
        mean = (a + b + c + d + e) / 5;
    }
}