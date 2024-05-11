namespace StartC_Sharp10.page_4;

public class KeywordThis
{
    public static void Main(string[] args)
    {
        Game game1 = new Game(20000);
        Game game2 = new Game(50000);

        game1.Add();
        Console.WriteLine(game1.Money);
        Console.WriteLine(game2);
    }
}

public class Game
{
    public static int B = 10;               // 클래스 소속
    public int Money;                       // 생성된 인스턴스 소속

    public Game(int money1)
    {
        Money = money1; // 메서드 소속
        this.Add();
        Console.WriteLine(this);
    }

    public void Add()
    {
        Console.WriteLine(this.Money);
    }
}