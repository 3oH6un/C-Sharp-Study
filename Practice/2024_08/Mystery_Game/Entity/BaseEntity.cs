namespace Practice._2024_08.Mystery_Game.Entity;

public class BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool Founded { get; private set; }

    public BaseEntity()
    {
    }

    public BaseEntity(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }
}