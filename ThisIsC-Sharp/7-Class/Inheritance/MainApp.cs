namespace ThisIsC_Sharp._7_Class.Inheritance;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Base a = new Base("a");
        a.BaseMethod();

        Derived b = new Derived("b");
        b.BaseMethod();
        b.DerivedMethod();
    }
}

class Base
{
    protected string Name;

    public Base(string name)
    {
        this.Name = name;
        Console.WriteLine($"{this.Name}.Base()");
    }

    ~Base()
    {
        Console.WriteLine($"{this.Name}.~Base()");
    }

    public void BaseMethod()
    {
        Console.WriteLine($"{Name}.BaseMethod");
    }
}

class Derived : Base
{
    public Derived(string Name) : base(Name)
    {
        Console.WriteLine($"{this.Name}.Derived()");
    }

    ~Derived()
    {
        Console.WriteLine($"{this.Name}.~Derived()");
    }

    public void DerivedMethod()
    {
        Console.WriteLine($"{Name}.DerivedMethod()");
    }
}