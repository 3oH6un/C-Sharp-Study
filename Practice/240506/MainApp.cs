namespace Practice._240506;

public class MainApp
{
    public static void _Main(string[] args)
    {
        MyClass A = new MyClass();
        MyClass B = new MyClass("ASDF", 10);

        A.SetMyField1("WOWOW");
        A.SetMyField2(100);

        Console.WriteLine($"{A.GetMyField1()}, {A.GetMyField2()}");
        Console.WriteLine($"{B.GetMyField1()}, {B.GetMyField2()}");
        Console.WriteLine($"{InstanceCount.GetCount()}");
    }
}

static class InstanceCount
{
    private static int _count = 0;

    public static void SetCount(int Count)
    {
        InstanceCount._count = Count;
    }

    public static int GetCount()
    {
        return _count;
    }
}

class MyClass
{
    private string MyField1;
    private int MyField2;

    public MyClass()
    {
        int Count = InstanceCount.GetCount();
        Count++;
        InstanceCount.SetCount(Count);
    }

    public MyClass(string MyField1, int MyField2) : this()
    {
        this.MyField1 = MyField1;
        this.MyField2 = MyField2;
    }

    public void SetMyField1(string MyField1)
    {
        this.MyField1 = MyField1;
    }

    public string GetMyField1()
    {
        return MyField1;
    }

    public void SetMyField2(int MyField2)
    {
        this.MyField2 = MyField2;
    }

    public int GetMyField2()
    {
        return MyField2;
    }

    ~MyClass()
    {
        InstanceCount.SetCount(InstanceCount.GetCount() - 1);
    }
}