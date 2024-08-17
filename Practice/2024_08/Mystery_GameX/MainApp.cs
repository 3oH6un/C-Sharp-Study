using Practice._2024_08.Mystery_GameX.Texts;
using Practice._2024_08.Mystery_GameX;

namespace Practice._2024_08.Mystery_GameX;

public class MainApp
{
    static void _Main(string[] args)
    {
        while (true)
        {
            // 각 객체 선언 및 초기화, 의존성 주입
            Player player = new Player();
            GameManager gameManager = new GameManager(player);
            TextManager textManager = new TextManager(gameManager);

            // 게임 시작 메시지 출력
            textManager.FirstStartText();
            
            // 게임 A 시작
            textManager.StartGameA();
        }
    }
}