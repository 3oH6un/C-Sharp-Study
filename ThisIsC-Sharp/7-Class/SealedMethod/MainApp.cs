namespace ThisIsC_Sharp._7_Class.SealedMethod;

public class MainApp
{
    static void _Main(string[] args)
    {
    }
}

class Base
{
    public virtual void SealMe()
    {
    }
}

class Derived : Base
{
    public sealed override void SealMe()
    {
    }
}

// class WantToOverride : Derived
// {
//     public override void SealMe()
//     {
//     }
// }