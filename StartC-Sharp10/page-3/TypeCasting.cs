namespace StartC_Sharp10.page_3;

public class TypeCasting
{
    public static void _Main(string[] args)
    {
        int n = 65536;
        short s = (short) n;
        Console.WriteLine("short : " + s);

        ushort us = (ushort)n;
        Console.WriteLine("ushort : " + us);

    }
}