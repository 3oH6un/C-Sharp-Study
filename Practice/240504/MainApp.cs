namespace Practice._240504;

public class MainApp
{
    public static void _Main()
    {
        Weapon[] weapons =
        [
            new Weapon(1, "칼", 0, 0, 0),
            new Weapon(2, "총", 1, 1, 1),
            new Weapon(3, "체인소", 2, 2, 2)
        ];

        Console.Write("무기의 종류는 ");
        foreach (var weapon in weapons.Select((value, index) => (index, value)))
        {
            Console.Write($"{weapon.index + 1}.{weapon.value.GetName()} ");
        }

        Console.WriteLine("입니다.");

        Console.Write("설명을 원하는 무기의 번호를 입력하세요.: ");

        weapons[Convert.ToInt32(Console.ReadLine()) - 1].ToString();
    }
}

public class Weapon
{
    private int type;
    private string name;
    private int damage;
    private int speed;
    private int count;

    public Weapon(int type, string name, int damage, int speed, int count)
    {
        this.type = type;
        this.name = name;
        this.damage = damage;
        this.speed = speed;
        this.count = count;
    }

    public int GetType1()
    {
        return this.type;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public int GetSpeed()
    {
        return this.speed;
    }

    public int GetCount()
    {
        return this.count;
    }

    public new void ToString()
    {
        Console.WriteLine($"무기의 이름은 {name}입니다.");
        Console.WriteLine($"무기의 대미지는 {damage}입니다.");
        Console.WriteLine($"무기의 스피드는 {speed}입니다.");
        Console.WriteLine($"무기의 갯수는 {count}입니다.");
    }
}

class Animal
{
    protected string name;
}

class Cat : Animal
{
    public Cat()
    {
    }

    Cat(string name)
    {
        this.name = name;
    }
}