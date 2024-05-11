namespace StartC_Sharp10.page_4;

public class Constructor
{
    public static void _Main(string[] args)
    {
        Person.president.DisplayName();

        Person unghoe = new Person("웅회");
    }
}

public class Person
{
    public static Person president;
    private string _name;

    static Person()
    {
        president = new Person("대통령");
    }

    public Person(string name)
    {
        _name = name;
    }

    public void DisplayName()
    {
        // Math.PI;
        Math.Abs(-100);
        Console.WriteLine(_name);
    }
}
