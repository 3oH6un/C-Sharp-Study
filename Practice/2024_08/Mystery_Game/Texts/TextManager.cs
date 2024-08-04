using Practice._2024_08.Mystery_Game.Texts.GameTexts;
using static System.Console;

namespace Practice._2024_08.Mystery_Game.Texts;

/// <summary>
/// 입출력 관리
/// </summary>
public class TextManager
{
    // 게임 매니저 객체 선언
    private readonly GameManager _gameManager;
    
    // 기본 생성자, 객체 비어있는지 확인, 의존성 주입
    public TextManager(GameManager gameManager)
     {
         this._gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
     }
    
    // 초기 시작 메시지 출력
    public void FirstStartText()
     {
         Clear();
         Functions.TextDelay("<범죄는 흔적을 남긴다>", 200);
         Thread.Sleep(1000);
         Write("\nEnter키를 눌러 이야기를 시작하세요.");
         Functions.GetUserInput();
         
         Clear();
         WriteLine("이야기 진행은 Enter키를 눌러주세요.");
         Functions.GetUserInput();
     }
    
    // 각 게임별 메시지
    public void StartGameA() { GameA.PrintText(); }
    public void StartGameB() { GameB.PrintText(); }
    public void StartGameC() { GameC.PrintText(); }
    public void StartGameD() { GameD.PrintText(); }
    public void StartGameE() { GameE.PrintText(); }
}