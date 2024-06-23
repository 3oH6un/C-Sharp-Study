namespace Practice._2024_05.Practice_2;

public class MainApp
{
    public static void _Main(string[] args)
    {
        MyClass A = new MyClass(100, "asdf");
        MyClass B = new MyClass();

        B.SetMyField1(100);
        B.SetField2("DDDD");

        Console.WriteLine($"{A.GetMyField1()}, {A.GetMyField2()}");
        Console.WriteLine($"{B.GetMyField1()}, {B.GetMyField2()}");
        Console.WriteLine(MyClass.Count);
    }
}

class MyClass
{
    public static int Count = 0;

    private int _myField1 = 0;
    private string _myField2 = "";

    public MyClass()
    {
        Count++;
    }

    public MyClass(int myField1, string myField2) : this()
    {
        this._myField1 = myField1;
        this._myField2 = myField2;
    }

    public void SetMyField1(int myField1)
    {
        this._myField1 = myField1;
    }

    public int GetMyField1()
    {
        return _myField1;
    }

    public void SetField2(string myField2)
    {
        this._myField2 = myField2;
    }

    public string GetMyField2()
    {
        return _myField2;
    }
}

