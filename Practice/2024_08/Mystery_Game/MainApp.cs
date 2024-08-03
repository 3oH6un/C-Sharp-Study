namespace Practice._2024_08.Mystery_Game;

public class MainApp
{
    static void Main(string[] args)
    {
        while (true)
        {
            TextManager controller = new TextManager();

            controller.StartGameText();
            controller.AddPlayerName();
            controller.BeforeCase1();
        }
    }
}