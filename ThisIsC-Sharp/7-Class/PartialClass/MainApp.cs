namespace ThisIsC_Sharp._7_Class.PartialClass;

public class MainApp
{
    public static void _Main(string[] args)
    {
        string a = "asdf";
        int b = 10;
        MyClass obj = new MyClass();
        obj.Method1();
        obj.Method2();
        obj.Method3();
        obj.Method4();
    }
}

partial class MyClass
{
    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    public void Method2()
    {
        Console.WriteLine("Method2");
    }
}

partial class MyClass
{
    public void Method3()
    {
        Console.WriteLine("Method3");
    }

    public void Method4()
    {
        Console.WriteLine("Method4");
    }
}