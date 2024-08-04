using Practice._2024_08.Mystery_Game.Texts.GameTexts;
using static System.Console;

namespace Practice._2024_08.Mystery_Game.Texts;

public class TextManager
{
    private readonly GameManager _gameManager;
    
    public TextManager(GameManager gameManager)
     {
         this._gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
     }
    
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
    
    public void StartGameA() { GameA.PrintText(); }
    public void StartGameB() { GameB.PrintText(); }
    public void StartGameC() { GameC.PrintText(); }
    public void StartGameD() { GameD.PrintText(); }
    public void StartGameE() { GameE.PrintText(); }
}