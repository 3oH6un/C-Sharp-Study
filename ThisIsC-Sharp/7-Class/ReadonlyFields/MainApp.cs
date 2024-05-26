namespace ThisIsC_Sharp._7_Class.ReadonlyFields;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Configuration c = new Configuration(100, 10);
    }
}

class Configuration
{
    private readonly int min;
    private readonly int max;

    public Configuration(int v1, int v2)
    {
        min = v1;
        min = v2;
    }

    public void ChangeMax(int newMax)
    {
        // max = newMax;
    }
}