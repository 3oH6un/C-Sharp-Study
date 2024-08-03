namespace Practice._2024_08.Mystery_Game;

/// <summary>
/// 인물 객체
/// </summary>
public class Person
{
    private readonly string _name;

    public Person(string name)
    {
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }
}

/// <summary>
/// 도구 객체
/// </summary>
public class Tool
{
    private readonly string _name;

    public Tool(string name)
    {
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }
}