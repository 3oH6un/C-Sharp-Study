namespace Practice._2024_06.Notepad.Initial;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Memo memo = new Memo();
        List<string> temp = new List<string>();

        Program.StartProgram();

        while (true)
        {
            string userInput = Program.ReadUserInput();

            if (userInput == "종료")
            {
                break;
            }

            else if (userInput == "보기")
            {
                Program.Wait(500);
                // Program.Print(memo.GetContents());
                Program.Print(memo.ToString());
                Program.AfterPrint();
                Program.StartProgram();
            }

            else if (userInput == "저장")
            {
                memo.AddContent(temp);
            }

            else
            {
                temp.Add(userInput);
            }
        }
    }
}

public static class Program
{
    public static void StartProgram()
    {
        Console.WriteLine("=== 메모장 기능 테스트 ===");
        Console.WriteLine("기능: 보기, 저장, 종료");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
    }

    public static void Wait(int time)
    {
        Console.Write("\n불러오는 중..");
        Thread.Sleep(time);
        Console.WriteLine(".\n");
        Thread.Sleep(time);
    }

    public static string ReadUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput;
    }

    public static void AfterPrint()
    {
        Console.WriteLine("\n내용을 불러왔습니다.");
        Console.WriteLine("처음으로 돌아가시려면 Enter 키를 눌러주세요.");
        Console.ReadLine();
    }

    public static void Print(List<string> texts)
    {
        foreach (var text in texts)
        {
            Console.WriteLine(text);
        }
    }
    public static void Print(string text)
    {
        Console.WriteLine(text);
    }
}

public class Memo
{
    private List<string> _contents;

    public Memo()
    {
        _contents = new List<string>();
    }

    public List<string> GetContents()
    {
        return this._contents;
    }

    public void AddContent(List<string> contents)
    {
        _contents.AddRange(contents);
    }

    public override string ToString()
    {
        return string.Join("\n", _contents);
    }
}