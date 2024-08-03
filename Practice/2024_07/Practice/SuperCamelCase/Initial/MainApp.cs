namespace Practice._2024_07.Practice.SuperCamelCase.Initial;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Converter converter = new Converter();
        Controller controller = new Controller(converter);
        controller.StartProgram();

        while (true)
        {
            string userInput = controller.GetUserInput();
            if (userInput == "exit") 
                break;
            
            controller.StartProgram();
            controller.PrintResult(controller.Convert(userInput));
        }
    }
}

public class Controller
{
    private Converter _converter;

    public Controller(Converter converter)
    {
        _converter = converter;
    }

    public string GetUserInput()
    {
        string? userInput = Console.ReadLine();
        userInput ??= "";
        return userInput;
    }
    
    public void StartProgram()
    {
        Console.Clear();
        Console.WriteLine("빡센 카멜 케이스 변환 알고리즘 테스트\t종료: exit");
    }
    
    public void PrintResult(string input)
    {
        Console.WriteLine(input);
    }

    public string Convert(string input)
    {
        while (string.IsNullOrEmpty(input))
        {
            StartProgram();
            Console.WriteLine("올바른 값을 입력해주세요.");
            input = GetUserInput();
        }
        
        return _converter.ToCamelCase(input);
    }
}

public class Converter
{
    public string ToCamelCase(string input)
    {
        char[] arr = input.ToCharArray();
        int j = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (j % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);

            else
                arr[i] = char.ToLower(arr[i]);

            j++;
        }
        
        return new string(arr);
    }
}