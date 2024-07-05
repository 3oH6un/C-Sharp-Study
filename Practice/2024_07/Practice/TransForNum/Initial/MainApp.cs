namespace Practice._2024_07.Practice.TransForNum.Initial;

public class MainApp
{
    public static void _Main()
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
    
    public void StartProgram()
    {
        Console.Clear();
        Console.WriteLine("숫자 변환 알고리즘 테스트\t종료: exit");
    }

    public string GetUserInput()
    {
        string? userInput = Console.ReadLine();
        userInput ??= "";
        return userInput;
    }

    public void PrintResult(int input)
    {
        Console.WriteLine(input);
    }

    public int Convert(string input)
    {
        while (string.IsNullOrEmpty(input))
        {
            StartProgram();
            Console.WriteLine("올바른 값을 입력해주세요.");
            input = GetUserInput();
        }

        while (_converter.ToNumber(input) == -1)
        {
            StartProgram();
            Console.WriteLine("올바른 값을 입력해주세요.");
            input = GetUserInput();
        }
        
        StartProgram();
        return _converter.ToNumber(input);
    }
}

public class Converter
{
    public int ToNumber(string input)
    {
        input = input.Replace("zero", "0");
        input = input.Replace("one", "1");
        input = input.Replace("two", "2");
        input = input.Replace("three", "3");
        input = input.Replace("four", "4");
        input = input.Replace("five", "5");
        input = input.Replace("six", "6");
        input = input.Replace("seven", "7");
        input = input.Replace("eight", "8");
        input = input.Replace("nine", "9");
        input = input.Replace("영", "0");
        input = input.Replace("일", "1");
        input = input.Replace("이", "2");
        input = input.Replace("삼", "3");
        input = input.Replace("사", "4");
        input = input.Replace("오", "5");
        input = input.Replace("육", "6");
        input = input.Replace("칠", "7");
        input = input.Replace("팔", "8");
        input = input.Replace("구", "9");
        
        if (int.TryParse(input, out _))
            return int.Parse(input);
        
        else
            return -1;
    }
}