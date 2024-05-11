namespace StartC_Sharp10.page_3;

public class TypeKeyword
{
     private int a = 10;

     public static void _Main(string[] args)
     {
          int result = Add(1, 2);
          Console.WriteLine(result);

          // const int maxN = Math.Max(0, 5);
     }

     public static int Add(int a, int b)
     {
          int first = a;
          int second = b;
          return first + second;
     }
}