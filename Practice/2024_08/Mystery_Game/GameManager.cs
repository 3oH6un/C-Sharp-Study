using System.Runtime.CompilerServices;

namespace Practice._2024_08.Mystery_Game;

/// <summary>
/// 게임 기능
/// </summary>
public class GameManager
{
    private List<Person> _persons = [];
    private List<Tool> _tools = [];

    public void AddPlayer(string name)
    {
        Person player = new Person(name);
        this._persons.Add(player);
    }

    public void SetTools(Tool tool)
    {
        this._tools.Add(tool);
    }

    public bool CheckForEmtpy(string text)
    {
        return string.IsNullOrEmpty(text);
    }
}