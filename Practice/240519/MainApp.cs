namespace Practice._240519;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Car A = new SonataHybrid();
        Car B = new Kia();

        A.MoveForward();
        B.MoveForward();
    }
}

class Car
{
    public Car(string a = "Car")
    {
        Console.WriteLine($"{a} 출고");
    }

    public virtual void MoveForward()
    {
        Console.WriteLine($"Car 앞으로 이동");
    }

    public virtual void MoveBackward()
    {
        Console.WriteLine($"Car 뒤로 이동");
    }

    public void MoveRight()
    {
        Console.WriteLine($"Car 우로 이동");
    }

    public void MoveLeft()
    {
        Console.WriteLine($"Car 좌로 이동");
    }
}

class Hyundai : Car
{
    public Hyundai(string a = "Hyundai") : base(a)
    {
    }

    public override void MoveForward()
    {
        Console.WriteLine($"Hyundai 앞으로 이동");
    }

    public override void MoveBackward()
    {
        Console.WriteLine($"Hyundai 뒤로 이동");
    }
}

class Sonata : Hyundai
{
    public Sonata(string a = "Sonata") : base(a)
    {
    }

    public sealed override void MoveForward()
    {
        Console.WriteLine($"Sonata 앞으로 이동");
    }

    public sealed override void MoveBackward()
    {
        Console.WriteLine($"Sonata 뒤로 이동");
    }
}

class SonataHybrid : Sonata
{
    public SonataHybrid(string a = "SonataHybrid") : base(a)
    {
    }
}

class Kia : Car
{
    public Kia(string a = "Kia") : base(a)
    {
    }

    public new void MoveForward()
    {
        Console.WriteLine($"Kia 앞으로 이동");
    }

    public new void MoveBackward()
    {
        Console.WriteLine($"Kia 뒤로 이동");
    }
}