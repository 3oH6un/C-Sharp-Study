namespace Practice._240506;

public class MainApp
{
    public static void _Main(string[] args)
    {
        MyClass a = new MyClass();
        MyClass b = new MyClass("ASDF", 10);

        a.SetMyField1("WOWOW");
        a.SetMyField2(100);

        Console.WriteLine($"{a.GetMyField1()}, {a.GetMyField2()}");
        Console.WriteLine($"{b.GetMyField1()}, {b.GetMyField2()}");
        Console.WriteLine($"{InstanceCount.GetCount()}");
    }
}

static class InstanceCount
{
    private static int _count = 0;

    public static void SetCount(int count)
    {
        InstanceCount._count = count;
    }

    public static int GetCount()
    {
        return _count;
    }
}

class MyClass
{
    private string _myField1 = "";
    private int _myField2 = 0;

    public MyClass()
    {
        int count = InstanceCount.GetCount();
        count++;
        InstanceCount.SetCount(count);
    }

    public MyClass(string myField1, int myField2) : this()
    {
        this._myField1 = myField1;
        this._myField2 = myField2;
    }

    public void SetMyField1(string myField1)
    {
        this._myField1 = myField1;
    }

    public string GetMyField1()
    {
        return _myField1;
    }

    public void SetMyField2(int myField2)
    {
        this._myField2 = myField2;
    }

    public int GetMyField2()
    {
        return _myField2;
    }

    ~MyClass()
    {
        InstanceCount.SetCount(InstanceCount.GetCount() - 1);
    }
}