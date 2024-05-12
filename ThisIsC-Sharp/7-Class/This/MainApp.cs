namespace ThisIsC_Sharp._7_Class.This;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Employee pooh = new Employee();
        pooh.SetName("푸");
        pooh.SetPosition("웨이터");

        Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

        Employee tigger = new Employee();
        tigger.SetName("타이거");
        tigger.SetPosition("청소부");

        Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
    }
}

class Employee
{
    private string _name;
    private string _position;

    public Employee()
    {
    }

    public Employee(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void SetName(string name)
    {
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }

    public void SetPosition(string position)
    {
        this._position = position;
    }

    public string GetPosition()
    {
        return this._position;
    }
}