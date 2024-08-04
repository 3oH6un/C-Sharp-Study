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
    private readonly GameA _gameA = new GameA();
    private readonly GameB _gameB = new GameB();
    private readonly GameC _gameC = new GameC();
    private readonly GameD _gameD = new GameD();
    private readonly GameE _gameE = new GameE();
    
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
         
         Clear();
         WriteLine("게임 진행시 선택지에서 괄호() 안에 단어로도 선택할 수 있습니다.");
         Functions.GetUserInput();
     }
    
    // 각 게임별 메시지
    public void StartGameA()
    {
        _gameA.PrintText1();

        while (true)
        {
            _gameA.PrintMain();
            string userInput = Functions.GetUserInput();
            
            switch (_gameManager.PlayerSelect(userInput))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                //
                // 여기부터 다시
                //
            }
        }
    }
    public void StartGameB() { _gameB.PrintText1(); }
    public void StartGameC() { _gameC.PrintText1(); }
    public void StartGameD() { _gameD.PrintText1(); }
    public void StartGameE() { _gameE.PrintText1(); }
}