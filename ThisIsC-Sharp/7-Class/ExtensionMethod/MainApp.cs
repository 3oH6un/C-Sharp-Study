using ThisIsC_Sharp._7_Class.MyExtension;

namespace ThisIsC_Sharp._7_Class.ExtensionMethod
{
    class MainApp
    {
        public static void _Main(string[] args)
        {
            Console.WriteLine($"3^2 : {3.Square()}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            Console.WriteLine($"2^10 : {2.Power(10)}");
            Console.WriteLine($"reverse ASDF: {"ASDF".Reverser()}");
        }
    }
}

namespace ThisIsC_Sharp._7_Class.MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
            {
                result = result * myInt;
            }

            return result;
        }
    }

    public static class StringExtension
    {
        public static string Reverser(this string myString)
        {
            char[] reverseString = new char[myString.Length];
            for (int i = myString.Length - 1; i >= 0; i--)
            {
                reverseString[myString.Length - 1 - i] = (myString[i]);
            }

            return new String(reverseString);
        }
    }
}