namespace ThisIsC_Sharp._7_Class.Constructor;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Cat kitty = new Cat("키티", "하얀색");
        kitty.Meow();
        Console.WriteLine($"{kitty.Name} : {kitty.Color}");

        Cat nero = new Cat("네로", "검은색");
        nero.Meow();
        Console.WriteLine($"{nero.Name} : {nero.Color}");
    }
}

class Cat
{
    public string Name;
    public string Color;

    public Cat()
    {
        Name = "";
        Color = "";
    }

    public Cat(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public void Meow()
    {
        Console.WriteLine($"{Name} : 야옹");
    }

    ~Cat()
    {
        Console.WriteLine($"{Name} : 잘가");
    }
}