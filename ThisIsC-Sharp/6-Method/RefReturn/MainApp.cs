namespace ThisIsC_Sharp._6_Method.RefReturn;

public class Product
{
    private int price = 100;

    public ref int GetPrice()
    {
        return ref price;
    }

    public void PrintPrice()
    {
        Console.WriteLine($"Price :{price}");
    }
}

public class MainApp
{
    static void _Main()
    {
        Product carrot = new Product();
        ref int refLocalPrice = ref carrot.GetPrice();
        int normalLocalPrice = carrot.GetPrice();

        carrot.PrintPrice();
        Console.WriteLine($"Ref Local Price :{refLocalPrice}");
        Console.WriteLine($"Normal Local Price :{normalLocalPrice}");

        refLocalPrice = 200;

        carrot.PrintPrice();
        Console.WriteLine($"Ref Local Price :{refLocalPrice}");
        Console.WriteLine($"Normal Local Price :{normalLocalPrice}");
    }
}