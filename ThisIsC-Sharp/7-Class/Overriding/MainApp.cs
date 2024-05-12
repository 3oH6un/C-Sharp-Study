namespace ThisIsC_Sharp._7_Class.Overriding;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Console.WriteLine("Creating ArmorSuite...");
        ArmorSuite armorSuite = new ArmorSuite();
        armorSuite.Initialize();

        Console.WriteLine("\nCreating IronMan...");
        ArmorSuite ironMan = new IronMan();
        ironMan.Initialize();

        Console.WriteLine("\nCreating WarMachine...");
        ArmorSuite warMachine = new WarMachine();
        warMachine.Initialize();
    }
}

class ArmorSuite
{
    public virtual void Initialize()
    {
        Console.WriteLine("Armored");
    }
}

class IronMan : ArmorSuite
{
    public override void Initialize()
    {
        base.Initialize();
        Console.WriteLine("Repulsor Rays Armed");
    }
}

class WarMachine : ArmorSuite
{
    public override void Initialize()
    {
        base.Initialize();
        Console.WriteLine("Double-Barrel Cannons Armed");
        Console.WriteLine("Mirco-Rocket Launcher Armed");
    }
}