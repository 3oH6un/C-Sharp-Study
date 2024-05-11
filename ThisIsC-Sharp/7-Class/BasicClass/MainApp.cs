namespace ThisIsC_Sharp._7_Class.BasicClass;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Cat kitty = new Cat();
        kitty.Name = "키티";
        kitty.Color = "하얀색";
        kitty.Meow();
        Console.WriteLine($"{kitty.Name} : {kitty.Color}");

        Cat nero = new Cat();
        nero.Name = "네로";
        nero.Color = "검은색";
        nero.Meow();
        Console.WriteLine($"{nero.Name} : {nero.Color}");
    }
}

class Cat
{
    public string Name;
    public string Color;

    public void Meow()
    {
        Console.WriteLine($"{Name} : 야옹");
    }
}