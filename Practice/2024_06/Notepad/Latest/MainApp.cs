namespace Practice._2024_06.Notepad.Latest;

public class MainApp
{
    static void _Main(string[] args)
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

    // 프로그램 시작 안내 메시지 출력 메서드
    public void StartProgram()
    {
        Console.WriteLine("=== 메모장 기능 테스트 ===");
        Console.WriteLine("기능: 보기, 저장, 종료");
        Console.WriteLine("메모하실 내용을 아래에 입력해주세요.");
    }

    // 사용자 입력 받는 메서드
    public string GetUserInput()
    {
        var userInput = Console.ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }

    // 입력된 내용 임시 저장하는 메서드
    public void SaveTemp(string text)
    {
        _memoService.AddTemp(text);
    }

    // 내용 저장 및 제목 입력 받는 메서드
    public void SaveTitle()
    {
        string temps = string.Join("\n", _memoService.GetTemp());
        
        // 내용이 비어있으면 입력 대기 후 돌아가기
        if (_memoService.CheckForEmpty(temps) == 1)
        {
            Console.Clear();
            Console.WriteLine("\n작성된 내용이 없습니다.");
            AfterPrint();
            return;
        }
        
        // else 삭제 리팩토링
        Console.WriteLine("\n저장하시려는 내용의 제목을 입력해주세요.");
        string userInput = GetUserInput();
        CheckForEmpty(userInput);
        string checkedInput = CheckForOverlap(userInput);
        _memoService.SaveMemo(checkedInput);
        _memoService.ClearTemp();
        Console.WriteLine($"\n제목:{checkedInput} (으)로 저장되었습니다.");
        AfterPrint();
    }

    // 임시 저장된 내용 출력하는 메서드
    public void PrintTemp()
    {
        List<string> temp = _memoService.GetTemp();
        
        foreach (var temps in temp)
        {
            Console.WriteLine(temps);
        }
    }
    
    // 제목 목록 출력하는 메서드
    public void PrintTitles()
    {
        Console.Clear();
        string titles = _memoService.GetTitles();
        List<string> titleList = [..titles.Split("\n")];
        Console.WriteLine(titles);
        
        // 제목이 비어있으면 입력 대기 후 돌아가기
        if (_memoService.CheckForEmpty(titles) == 1)
        {
            Console.WriteLine("저장된 메모가 없습니다.");
            AfterPrint();
            return;
        }
        
        // else 삭제 리팩토링
        _memoService.CheckForEmpty(titles);
        Console.WriteLine("\n열람하실 메모의 제목을 입력해주세요.");
        string userInput = GetUserInput();
        int idx = titleList.IndexOf(userInput);
        Console.Clear();

        // titleList에서 사용자 입력과 같은 값이 있는지 확인 후 없으면 -1을 반환 받고 오류 메시지 출력
        while (idx < 0)
        {
            Console.WriteLine(titles);
            Console.WriteLine($"\n{userInput}을(를) 찾을 수 없습니다. 올바른 제목을 입력해주세요.");
            idx = titleList.IndexOf(userInput = GetUserInput());
            Console.Clear();
        }

        Console.WriteLine($"idx: {idx}");
        Console.WriteLine(_memoService.GetMemo(idx));
        AfterPrint();
    }

    // 출력 이후 입력 대기 메서드
    private void AfterPrint()
    {
        Console.WriteLine("처음으로 돌아가시거나 입력을 계속하시면 Enter 키를 눌러주세요.");
        GetUserInput();
        Console.Clear();
    }
    
    // 프로그램 종료 메시지 출력 메서드
    public void ExitProgramForSecond(int time)
    {
        Console.WriteLine($"\n{time}초 뒤 메모장을 종료합니다.");
        var timescale = time * 1000;
        Thread.Sleep(timescale);
    }

    // 제목이 비어있는지 확인하는 메서드
    private void CheckForEmpty(string text)
    {
        while (_memoService.CheckForEmpty(text) == 1)
        {
            Console.WriteLine("올바른 제목을 입력해주세요.");
            text = GetUserInput();
        }
    }

    // 제목이 중복되는지 확인하는 메서드
    private string CheckForOverlap(string text)
    {
        string titles = _memoService.GetTitles();
        // titles의 값에서 "\n"을 기준으로 쪼개서 반환
        List<string> titleList = [..titles.Split("\n")];
        
        // titleList에 text가 있다면 반복문 코드 실행
        while (titleList.Contains(text))
        {
            Console.WriteLine($"{text}이(가) 이미 있습니다. 다른 제목을 입력해주세요.");
            text = GetUserInput();
        }
        
        // titleList에 없는 입력을 받으면 값 반환
        return text;
    }
}

// 서비스(데이터 처리)
public class MemoService
{
    private MemoRepository _memoRepository = new MemoRepository();
    private List<string> _temp = [];

    // 내용 임시 저장하는 메서드
    public void AddTemp(string text)
    {
        _temp.Add(text);
    }

    // 임시 저장된 내용 비우는 메서드
    public void ClearTemp()
    {
        _temp.Clear();
    }

    // 임시 저장된 내용 가져오는 메서드
    public List<string> GetTemp()
    {
        return _temp;
    }

    // 임시 저장된 내용들을 memo 객체에 저장하는 메서드
    public void SaveMemo(string title)
    {
        // _temp의 요소들 사이에 "\n"을 넣고 하나의 string으로 변환 후 반환
        string content = string.Join("\n", _temp);
        Memo memo = new Memo(title, content);
        _memoRepository.AddMemo(memo);
    }

    // 값이 비어있는지 확인하는 메서드(비어있으면 1 반환)
    public int CheckForEmpty(string text)
    {
        // 삼항 연산자로 리팩토링
        return string.IsNullOrEmpty(text) ? 1 : 0;

        // if (string.IsNullOrEmpty(text))
        // {
        //     return 1;
        // }
        // else
        // {
        //     return 0;
        // }
    }

    // 저장된 제목들을 가져오는 메서드
    public string GetTitles()
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string> titles = [];
        
        foreach (var memo in memos)
        {
            titles.Add(memo.GetTitle());
        }

        // titles의 요소들 사이에 "\n"을 넣고 하나의 string으로 변환 후 반환
        return string.Join("\n", titles);
    }

    // 저장된 제목과 내용을 가져오는 메서드
    public string GetMemo(int idx)
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string> memo = [
            $"제목: {memos[idx].GetTitle()}",
            memos[idx].GetContent()
        ];

        // memo의 요소들 사이에 "\n"을 넣고 하나의 string으로 변환 후 반환
        return string.Join("\n", memo);
    }
}

// 리포지토리(데이터 저장소)
public class MemoRepository
{
    private List<Memo> _database = [];

    // Memo 타입의 memo 객체를 저장하는 메서드
    public void AddMemo(Memo memo)
    {
        _database.Add(memo);
    }

    // memo 객체가 저장된 _database를 불러오는 메서드
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

    // 제목 가져오는 메서드
    public string GetTitle()
    {
        // 이 객체의 _title를 반환
        return this._title;
    }

    // 내용 가져오는 메서드
    public string GetContent()
    {
        // 이 객체의 _content를 반환
        return this._content;
    }
}