namespace Practice._2024_08.Mystery_Game.Entity;

public class Npc : BaseEntity
{
    public int Age { get; private set; }

    public Npc() : base()
    {
    }

    public Npc(string name, string description, int age) : base(name, description)
    {
        this.Age = age;
    }
}