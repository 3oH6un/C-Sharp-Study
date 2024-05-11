namespace ThisIsC_Sharp._7_Class.DeepCopy;

public class MainApp
{
    static void _Main()
    {
        Console.WriteLine("Shallow Copy");

        {
            MyClass source = new MyClass();
            source.MyField1 = 1;
            source.MyField2 = 2;

            MyClass target = source;
            target.MyField2 = 300;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
        }

        Console.WriteLine("Deep Copy");

        {
            MyClass source = new MyClass();
            source.MyField1 = 1;
            source.MyField2 = 1;

            MyClass target = source.DeepCopy();
            target.MyField1 = 10;
            target.MyField2 = 20;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
        }

        {
            MyClass source = new MyClass();
            source.MyField1 = 1;
            source.MyField2 = 1;

            MyClass target = new MyClass(myClass: source);
            target.MyField2 = 3;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
        }

        {
            MyClass source = new MyClass();
            source.MyField1 = 1;
            source.MyField2 = 1;

            MyClass target = new MyClass(myField1: source.MyField1, myField2: source.MyField2);
            target.MyField2 = 15;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
        }
    }
}

class MyClass : ICloneable
{
    public int MyField1;
    public int MyField2;

    public MyClass()
    {
    }

    public MyClass(int myField1, int myField2)
    {
        this.MyField1 = myField1;
        this.MyField2 = myField2;
    }

    public MyClass(MyClass myClass)
    {
        this.MyField1 = myClass.MyField1;
        this.MyField2 = myClass.MyField2;
    }

    public MyClass DeepCopy()
    {
        MyClass copy = new MyClass();
        copy.MyField1 = this.MyField1;
        copy.MyField2 = this.MyField2;
        return copy;
    }

    public object Clone()
    {
        return new MyClass(this.MyField1, this.MyField2);
    }
}