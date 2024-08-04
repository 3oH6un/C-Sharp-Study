using Practice._2024_08.Mystery_Game.Texts;
namespace Practice._2024_08.Mystery_Game;

public class MainApp
{
    static void Main(string[] args)
    {
        while (true)
        {
            // 각 객체 선언 및 초기화
            Player player = new Player();
            GameManager gameManager = new GameManager(player);
            TextManager controller = new TextManager(gameManager);

            // 게임 시작 메시지 출력
            controller.FirstStartText();
            
            // 게임 A 시작
            controller.StartGameA();
        }
    }
}