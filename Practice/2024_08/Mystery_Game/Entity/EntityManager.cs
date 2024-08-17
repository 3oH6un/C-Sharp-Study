using System.Xml;

namespace Practice._2024_08.Mystery_Game.Entity;

public class EntityManager
{
    public BaseEntity[] Npcs { get; } = 
    [
        new Npc(),
        new Npc(),
        new Npc(),
        new Npc(),
        new Npc()
    ];

    public BaseEntity[] Tools { get; } = 
    [
        new Tool(),
        new Tool(),
        new Tool(),
        new Tool(),
        new Tool()
    ];

    public BaseEntity[] Places { get; } =
    [
        new Place(),
        new Place(),
        new Place(),
        new Place(),
        new Place()
    ];

    private Place _currentPlace;

    // 노트 열람시 Founded가 True로 되어있는 객체만 꺼내주기
    public BaseEntity[] GetFounded(BaseEntity[] entities)
    {
        return entities.Where(entity => entity.Founded).ToArray();
    }
}