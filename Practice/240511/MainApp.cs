namespace Practice._240511;

public class MainApp
{
    public static void Main(string[] args)
    {
        MyClass Q = new MyClass(1, "ASDF");
        MyClass W = new MyClass();

        W.SetA(2);
        W.SetB("WWDD");

        MyClass E = Q.Clone();
        MyClass R = W.Clone();

        Console.WriteLine($"Count의 갯수는 {InstanceCount.GetCount()} 입니다.");
        Console.WriteLine(Q);
        Console.WriteLine(W);
        Console.WriteLine(E);
        Console.WriteLine(R);
    }
}

class MyClass
{
    private int _a;
    private string _b;

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
        return $"a: {_a}, b:{_b}";
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