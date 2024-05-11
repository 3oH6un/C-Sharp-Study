namespace Practice._240511;

public class MainApp
{
    public static void Main(string[] args)
    {
        MyClass q = new MyClass(1, "ASDF");
        MyClass w = new MyClass();

        w.SetA(2);
        w.SetB("WWDD");

        MyClass e = q.Clone();
        MyClass r = w.Clone();

        Console.WriteLine(q);
        Console.WriteLine(w);
        Console.WriteLine(e);
        Console.WriteLine(r);
        Console.WriteLine($"인스턴스가 생성된 횟수는 {InstanceCount.GetCount()}번 입니다.");
    }
}

class MyClass
{
    private int _a = 0;
    private string _b = "";

    public MyClass()
    {
        InstanceCount.SetCount(InstanceCount.GetCount() + 1);
    }

    public MyClass(int a, string b) : this()
    {
        this._a = a;
        this._b = b;
    }

    public int GetA()
    {
        return this._a;
    }

    public void SetA(int a)
    {
        this._a = a;
    }

    public string GetB()
    {
        return this._b;
    }

    public void SetB(string b)
    {
        this._b = b;
    }

    public MyClass Clone()
    {
        return new MyClass(this._a, this._b);;
    }

    public override string ToString()
    {
        return $"a:{_a}, b:{_b}";
    }
}

static class InstanceCount
{
    private static int _count = 0;

    public static int GetCount()
    {
        return _count;
    }

    public static void SetCount(int count)
    {
        _count = count;
    }
}