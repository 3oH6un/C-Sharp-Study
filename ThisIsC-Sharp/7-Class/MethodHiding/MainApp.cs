namespace ThisIsC_Sharp._7_Class.MethodHiding;

public class MainApp
{
    static void _Main(string[] args)
    {
        Base baseObj = new Base();
        baseObj.MyMethod();

        Derived derivedObj = new Derived();
        derivedObj.MyMethod();

        Base baseOrDerived = new Derived();
        baseOrDerived.MyMethod();
    }
}

class Base
{
    public void MyMethod()
    {
        Console.WriteLine("Base.MyMethod()");
    }
}

class Derived : Base
{
    public new void MyMethod()
    {
        Console.WriteLine("Derived.MyMethod()");
    }
}