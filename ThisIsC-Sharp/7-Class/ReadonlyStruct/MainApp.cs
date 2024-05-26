namespace ThisIsC_Sharp._7_Class.ReadOnlyStruct;

public class MainApp
{
    static void _Main(string[] args)
    {
        RGBColor Red = new RGBColor(255, 0, 0);
        // Red.G = 100;
    }
}

readonly struct RGBColor
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;

    public RGBColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}