namespace Practice._2024_08.Mystery_Game;

public class Player
{
    // 도구들을 담아두는 컬렉션
    private readonly List<Tool> _tools;

    // 기본 생성자
    public Player()
    {
        _tools = new List<Tool>();
    }
    
    // 읽기 전용 인터페이스 메서드
    public IReadOnlyList<Tool> GetTools()
    {
        return _tools.AsReadOnly();
    }

    // 도구 추가
    public void AddTool(Tool tool)
    {
        _tools.Add(tool);
    }
    
    // 도구 삭제
    public void RemoveTool(Tool tool)
    {
        _tools.Remove(tool);
    }

    // 도구 전부 삭제
    public void ClearTools()
    {
        _tools.Clear();
    }
}

/// <summary>
/// 도구 객체
/// </summary>
public class Tool
{
    // public으로 설정해두고 set접근자만 private로 객체 외부에서 수정 불가능하게 막아둠
    public string Name { get; private set; }
    public string Description { get; private set; }

    // 기본 생성자
    public Tool(string name, string description)
    {
        Name = name;
        Description = description;
    }
}