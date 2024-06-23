namespace Practice._240615;

public class MainApp
{
    static void _Main( )
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
        Console.WriteLine("=== 메모장 기능 테스트 ===");
        Console.WriteLine("기능: 보기, 저장, 종료");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
    }

    public string GetUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }

    public void SaveTemp(string text)
    {
        _memoService.AddTemp(text);
    }

    public void SaveTitle()
    {
        string temps = string.Join("\n", _memoService.GetTemp());
        
        if (_memoService.CheckForEmpty(temps) == 1)
        {
            Console.Clear();
            Console.WriteLine("\n작성된 내용이 없습니다.");
        }

        else
        {
            Console.WriteLine("\n저장하시려는 내용의 제목을 입력해주세요.");
            string userInput = GetUserInput();
            TitleCheckForEmpty(userInput);
            string checkedInput = TitleCheckForOverlap(userInput); // 제목 중복 확인 후 입력값 반환
            _memoService.SaveMemo(checkedInput);
            _memoService.ClearTemp();
            Console.WriteLine($"\n제목:{checkedInput} (으)로 저장되었습니다.");
        }
        
        AfterPrint();
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

        if (_memoService.CheckForEmpty(titles) == 1)
        {
            Console.WriteLine("저장된 메모가 없습니다.");
        }

        else
        {
            _memoService.CheckForEmpty(titles);
            Console.WriteLine("\n열람하실 메모의 제목을 입력해주세요.");
            string userInput = GetUserInput();
            int idx = titleList.IndexOf(userInput);
            Console.Clear();

            while (idx < 0)
            {
                Console.WriteLine(titles);
                Console.WriteLine($"\n{userInput}을(를) 찾을 수 없습니다. 올바른 제목을 입력해주세요.");
                idx = titleList.IndexOf(userInput = GetUserInput());
                Console.Clear();
            }

            Console.WriteLine($"idx: {idx}");
            Console.WriteLine(_memoService.GetMemo(idx));
        }
        
        AfterPrint();
    }

    // public void PrintMemos()
    // {
    //     string memos = _memoService.ToStringMemos();
    //
    //     if (string.IsNullOrEmpty(memos))
    //     {
    //         Console.WriteLine("\n아직 저장된 메모가 없습니다.");
    //     }
    //
    //     else
    //     {
    //         Console.WriteLine(memos);
    //     }
    //
    //     AfterPrint();
    // }

    private void AfterPrint()
    {
        Console.WriteLine("처음으로 돌아가시거나 입력을 계속하시면 Enter 키를 눌러주세요.");
        GetUserInput();
        Console.Clear();
    }
    
    public void ExitProgramForSecond(int time)
    {
        Console.WriteLine($"\n{time}초 뒤 메모장을 종료합니다.");
        var timescale = time * 1000;
        Thread.Sleep(timescale);
    }

    public void TitleCheckForEmpty(string text) // 제목 빈 값 확인
    {
        while (_memoService.CheckForEmpty(text) == 1)
        {
            Console.WriteLine("올바른 제목을 입력해주세요.");
            text = GetUserInput();
        }
    }

    public string TitleCheckForOverlap(string text) // 제목 중복 확인
    {
        string titles = _memoService.GetTitles();
        List<string> titleList = [..titles.Split("\n")];
        
        while (titleList.Contains(text))
        {
            Console.WriteLine($"{text}이(가) 이미 있습니다. 다른 제목을 입력해주세요.");
            text = GetUserInput();
        }
        
        return text;
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

    public void SaveMemo(string title)
    {
        string content = string.Join("\n", _temp);
        Memo memo = new Memo(title, content);
        _memoRepository.AddMemo(memo);
    }

    public int CheckForEmpty(string text) //빈 입력값 확인 메서드
    {
        if (string.IsNullOrEmpty(text))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    // public string ToStringMemos()
    // {
    //     List<Memo> memos = _memoRepository.GetDatabase();
    //     List<string?> allMemo = [];
    //     
    //     foreach (var memo in memos)
    //     {
    //         allMemo.Add(memo.ToString());
    //     }
    //
    //     return string.Join("\n", allMemo);
    // }

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