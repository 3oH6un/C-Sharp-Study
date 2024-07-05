namespace Practice._2024_05.Practice._1;

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
    private int _type;
    private string _name;
    private int _damage;
    private int _speed;
    private int _count;

    public Weapon(int type, string name, int damage, int speed, int count)
    {
        this._type = type;
        this._name = name;
        this._damage = damage;
        this._speed = speed;
        this._count = count;
    }

    public int GetType1()
    {
        return this._type;
    }

    public string GetName()
    {
        return this._name;
    }

    public int GetDamage()
    {
        return this._damage;
    }

    public int GetSpeed()
    {
        return this._speed;
    }

    public int GetCount()
    {
        return this._count;
    }

    public new void ToString()
    {
        Console.WriteLine($"무기의 이름은 {_name}입니다.");
        Console.WriteLine($"무기의 대미지는 {_damage}입니다.");
        Console.WriteLine($"무기의 스피드는 {_speed}입니다.");
        Console.WriteLine($"무기의 갯수는 {_count}입니다.");
    }
}

class Animal
{
    protected string Name = "";
}

class Cat : Animal
{
    public Cat()
    {
    }

    Cat(string name)
    {
        this.Name = name;
    }
}