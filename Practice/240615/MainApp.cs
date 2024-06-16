namespace Practice._240615;

public class MainApp
{
    static void Main(string[] args)
    {
        MemoController memoController = new MemoController();

        memoController.StartProgram();

        while (true)
        {
            string userInput = memoController.GetUserInput();

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
                // memoController.PrintMemos();
                memoController.PrintTitles();
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

    public string GetUserInput()
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
        string userInput = GetUserInput();

        while (_memoService.SaveMemo(userInput) == 1)
        {
            Console.WriteLine("올바른 제목을 입력해주세요.");
            userInput = GetUserInput();
        }

        _memoService.ClearTemp();
        Console.WriteLine($"\n제목:{userInput} 으로 저장되었습니다.");
        AfterPrint();
    }

    private void AfterPrint()
    {
        Console.WriteLine("처음으로 돌아가시거나 입력을 계속하시면 Enter 키를 눌러주세요.");
        GetUserInput();
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

    public void PrintTitles()
    {
        Console.Clear();
        string titles = _memoService.GetTitles();
        List<string> titleList = [..titles.Split("\n")];
        Console.WriteLine(titles);
        Console.WriteLine("열람하실 메모의 제목을 입력해주세요.");
        int idx = titleList.BinarySearch(GetUserInput());
        Console.Clear();

        while (idx < 0)
        {
            Console.WriteLine(titles);
            Console.WriteLine("올바른 제목을 입력해주세요.");
            idx = titleList.BinarySearch(GetUserInput());
            Console.Clear();
        }

        Console.WriteLine($"idx: {idx}");
        Console.WriteLine(_memoService.GetMemo(idx));
        AfterPrint();
    }

    public void PrintMemos()
    {
        string memos = _memoService.ToStringMemos();

        if (string.IsNullOrEmpty(memos))
        {
            Console.WriteLine("\n아직 저장된 메모가 없습니다.");
        }

        else
        {
            Console.WriteLine(memos);
        }

        AfterPrint();
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

    public int SaveMemo(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            return 1;
        }

        string content = string.Join("\n", _temp);
        Memo memo = new Memo(title, content);
        _memoRepository.AddMemo(memo);
        return 0;
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

    public string GetTitles()
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string> titles = [];
        foreach (var memo in memos)
        {
            titles.Add(memo.GetTitle());
        }

        return string.Join("\n", titles);
    }

    public string GetMemo(int idx)
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string> memo = [
            $"제목: {memos[idx].GetTitle()}",
            memos[idx].GetContent()
        ];

        return string.Join("\n", memo);
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
    private string _title;
    private string _content;

    public Memo(string title, string content)
    {
        this._title = title;
        this._content = content;
    }

    public string GetTitle()
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