namespace Practice._240615;

public class MainApp
{
    static void Main(string[] args)
    {
        MemoController memoController = new MemoController();
        
        memoController.StartProgram();

        while (true)
        {
            string userInput = memoController.ReadUserInput();
            
            if (userInput == "종료")
            {
                memoController.ExitProgramForSecond(1);
                break;
            }
            
            else if (userInput == "저장")
            {
                memoController.SaveTitle();
                memoController.StartProgram();
            }
            
            else if (userInput == "보기")
            {
                memoController.PrintMemos();
                memoController.StartProgram();
                memoController.PrintTemp();
            }

            else
            {
                memoController.SaveTemp(userInput);
            }
        }
    }
}

// 컨트롤러(입출력 관리)
public class MemoController
{
    private MemoService _memoService = new MemoService();

    public void StartProgram()
    {
        Console.WriteLine("\n=== 메모장 기능 테스트 ===");
        Console.WriteLine("기능: 보기, 저장, 종료");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
    }

    public string ReadUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput;
    }

    public void SaveTemp(string text)
    {
        _memoService.AddTemp(text);
    }

    public void SaveTitle()
    {
        Console.WriteLine("\n저장하시려는 내용의 제목을 입력해주세요.");
        string? userInput = Console.ReadLine();
        _memoService.SaveMemo(userInput);
        _memoService.ClearTemp();
        Console.WriteLine($"\n제목:{userInput} 으로 저장되었습니다.");
        Console.WriteLine("처음으로 돌아가시거나 입력을 계속하시면 Enter 키를 눌러주세요.");
        Console.ReadLine();
        Console.Clear();
    }

    public void PrintTemp()
    {
        List<string> temp = _memoService.GetTemp();
        foreach (var temps in temp)
        {
            Console.WriteLine(temps);
        }
    }
    
    public void PrintMemos()
    {
        string memos = _memoService.ToStringMemos();
        Console.Clear();
        Console.WriteLine(_memoService.ToStringMemos());
        if (string.IsNullOrEmpty(memos))
        {
            Console.WriteLine("\n아직 저장된 메모가 없습니다.");
        }
        Console.WriteLine("\n처음으로 돌아가시거나 입력을 계속하시면 Enter 키를 눌러주세요.\n");
        Console.ReadLine();
        Console.Clear();
    }

    public void ExitProgramForSecond(int time)
    {
        Console.WriteLine($"\n{time}초 뒤 메모장을 종료합니다.");
        var timescale = time * 1000;
        Thread.Sleep(timescale);
    }
}

// 서비스(데이터 처리)
public class MemoService
{
    private MemoRepository _memoRepository = new MemoRepository();
    private List<string> _temp = [];

    public void AddTemp(string text)
    {
        _temp.Add(text);
    }

    public void ClearTemp()
    {
        _temp.Clear();
    }

    public List<string> GetTemp()
    {
        return _temp;
    }

    public void SaveMemo(string? title)
    {
        string content = string.Join("\n", _temp);
        Memo memo = new Memo(title, content);
        _memoRepository.AddMemo(memo);
    }

    public string ToStringMemos()
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string?> allMemo = [];
        foreach (var memo in memos)
        {
            allMemo.Add(memo.ToString());
        }

        return string.Join("\n", allMemo);
    }
}

// 리포지토리(데이터 저장소)
public class MemoRepository
{
    private List<Memo> _database = [];

    public void AddMemo(Memo memo)
    {
        _database.Add(memo);
    }

    public List<Memo> GetDatabase()
    {
        return _database;
    }
}

// 엔티티(데이터)
public class Memo
{
    private string? _title;
    private string _content;

    public Memo(string? title, string content)
    {
        this._title = title;
        this._content = content;
    }

    public string? GetTitle()
    {
        return this._title;
    }

    public string GetContent()
    {
        return this._content;
    }

    public override string ToString()
    {
        return $"\n제목: {_title}\n{_content}";
    }
}