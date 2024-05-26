namespace ThisIsC_Sharp._7_Class.Exercise.Ex7_5;

public class MainApp
{
    static void _Main(string[] args)
    {
        ACSetting acs;
        acs.currentInCelsius = 25;
        acs.target = 25;

        Console.WriteLine($"{acs.GetFahrenheit()}");
        Console.WriteLine($"{acs.target}");
    }
}

struct ACSetting
{
    public double currentInCelsius;
    public double target;

    public readonly double GetFahrenheit() => currentInCelsius * 1.8 + 32;
}