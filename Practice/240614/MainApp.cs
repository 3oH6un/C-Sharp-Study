using System.Collections;

namespace Practice._240614;

public class MainApp
{
    public static void Main(string[] args)
    {
        string userInput = "";
        TextSave textSaver = new TextSave();

        Console.WriteLine("=== 메모장 기능 테스트 ===");
        Console.WriteLine("내용을 열람하시려면 '보기', 종료하시면 '종료'를 입력해주세요.");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
        
        while (true)
        {
            userInput = Console.ReadLine();
            
            if (userInput == "종료")
            {
                break;
            }
            
            else if (userInput == "보기")
            {
                textSaver.PrintContents();
            }
            
            else
            {
                textSaver.AddContent(userInput);
            }
        }
    }
}

public class TextSave
{
    private List<string> _contents;

    public TextSave()
    {
        _contents = new List<string>();
    }

    public void AddContent(string content)
    {
        _contents.Add(content);
    }

    public void PrintContents()
    {
        Console.Write("\n불러오는 중..");
        Thread.Sleep(500);
        Console.WriteLine(".\n");
        Thread.Sleep(500);
        
        foreach (var content in _contents)
        {
            Console.WriteLine(content);
        }
        
        Console.WriteLine("\n내용을 불러왔습니다.");
        Console.WriteLine("처음으로 돌아가시려면 Enter 키를 눌러주세요.");
        Console.ReadLine();
        Console.WriteLine("=== 메모장 기능 테스트 ===");
        Console.WriteLine("내용을 열람하시려면 '보기', 종료하시면 '종료'를 입력해주세요.");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
    }
}