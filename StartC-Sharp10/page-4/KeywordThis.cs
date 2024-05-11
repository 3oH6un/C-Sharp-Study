namespace StartC_Sharp10.page_4;

public class KeywordThis
{
    public static void Main(string[] args)
    // public  static void Main(string[] args)
    {
        Game game1 = new Game(20000);
        Game game2 = new Game(50000);

        game1.Add();
        Console.WriteLine(game1.money);
        // Console.WriteLine(game1);
    }
}

public class Game
{
    public static int b = 10;               // 클래스 소속
    public int money;                       // 생성된 인스턴스 소속

    public Game(int money1)
    {
        int a = 1;                          // 메서드 소속
        money = money1;
        this.Add();
        Console.WriteLine(this);
    }

    public void Add()
    {
        Console.WriteLine(this.money);
    }
}