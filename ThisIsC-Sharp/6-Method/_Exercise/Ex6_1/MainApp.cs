namespace ThisIsC_Sharp._Exercise.Ex6_1;

public class MainApp
{
    static double Square(double arg)
    {
        return arg * arg;
    }

    static void _Main(string[] args)
    {
        Console.Write("수를 입력하세요. : ");
        string input = Console.ReadLine();
        double arg = Convert.ToDouble(input);

        Console.WriteLine("결과 : {0}", Square(arg));
    }
}