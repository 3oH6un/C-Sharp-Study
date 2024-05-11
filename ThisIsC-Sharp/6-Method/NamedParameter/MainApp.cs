namespace ThisIsC_Sharp._6_Method.NamedParameter;

public class MainApp
{
    static void PrintProfile(string name, string phone)
    {
        Console.WriteLine($"Name:{name}, Phone:{phone}");
    }

    static void _Main(string[] args)
    {
        PrintProfile(name: "엄준식", phone: "010-1234-1234");
        PrintProfile(phone: "010-4645-4564", name: "김형섭");
        PrintProfile("꼭태민", "010-4434-8566");
        PrintProfile("김찬호", phone:"010-2233-2334");
    }
}