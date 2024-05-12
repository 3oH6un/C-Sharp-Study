namespace ThisIsC_Sharp._7_Class.TypeCasting;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Mammal mammal = new Dog();
        mammal.Nurse();

        Dog dog;
        if (mammal is Dog)
        {
            dog = (Dog)mammal;
            dog.Bark();
        }

        Mammal mammal2 = new Cat();
        Cat cat = mammal2 as Cat;

        if (cat != null)
        {
            cat.Meow();
        }

        Cat cat2 = mammal as Cat;
        if (cat2 != null)
        {
            cat2.Meow();
        }
        else
        {
            Console.WriteLine("cat2 is not a Cat");
        }
    }
}

class Mammal
{
    public virtual void Nurse()
    {
        Console.WriteLine("Nurse()");
    }
}

class Dog : Mammal
{

    public void Bark()
    {
        Console.WriteLine("Bark()");
    }
}

class Cat : Mammal
{
    public void Meow()
    {
        Console.WriteLine("Meow()");
    }
}