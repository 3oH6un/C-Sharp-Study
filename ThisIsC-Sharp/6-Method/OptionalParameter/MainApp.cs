using System.Diagnostics;

namespace ThisIsC_Sharp._6_Method.OptionalParameter;

public class MainApp
{
    static void PrintProfile(string name, string phone = "")
    {
        Console.WriteLine($"Name:{name}, Phone:{phone}");
    }

    static void _Main()
    {
        PrintProfile("중근");
        PrintProfile("관순", "010-123-1234");
        PrintProfile(name: "봉길");
        PrintProfile(name: "동주", phone: "010-554-2234");
    }
}