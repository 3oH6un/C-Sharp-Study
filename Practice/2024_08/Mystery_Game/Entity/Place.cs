namespace Practice._2024_08.Mystery_Game.Entity;

public class Place : BaseEntity
{
    public Npc Npc { get; private set; }
    public Tool Tool { get; private set; }

    public Place() : base()
    {
        
    }
    
    public Place(string name, string description, Npc npc, Tool tool) : base(name, description)
    {
        this.Npc = npc;
        this.Tool = tool;
    }
}