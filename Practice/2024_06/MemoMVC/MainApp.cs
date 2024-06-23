namespace Practice._2024_06.MemoMVC;

public class MainApp
{

}

// 컨트롤러(입출력 관리)
public class MemoController
{
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

    public void SaveMemo(string title)
    {
        string content = string.Join("\n", _temp);
        Memo memo = new Memo(title, content);
        _memoRepository.AddMemo(memo);
    }

    public string PrintMemo()
    {
        List<Memo> memos = _memoRepository.GetDatabase();
        List<string> allMemo = [];
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
    private readonly string _title;
    private readonly string _content;

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
        return $"제목: {_title}\n내용: {_content}";
    }
}