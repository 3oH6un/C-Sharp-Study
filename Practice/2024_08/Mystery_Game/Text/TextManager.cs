using static System.Console;

namespace Practice._2024_08.Mystery_Game;

public class TextManager
{
    private readonly GameManager _gameManager;
    
    public TextManager(GameManager gameManager)
     {
         this._gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
     }
    
    public void StartGameText()
     {
         Clear();
         Function.TextDelay("<범죄는 흔적을 남긴다>", 200);
         Thread.Sleep(1000);
         Write("\nEnter키를 눌러 이야기를 시작하세요.");
         Function.GetUserInput();
         
         Clear();
         WriteLine("이야기 진행은 Enter키를 눌러주세요.");
         Function.GetUserInput();
     }

    public void GameA()
    {
        Clear();
        Function.TextDelay("퇴근 후 집으로 가는 길...");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("내일부터 한달 동안 휴가를 보내게 되었다.");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("여태 미뤄놨던 게임을 할 시간이다..");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("얼른 가서 씻고 컴퓨터를 켜야..");
        Function.GetUserInput();
        
        Clear();
        Write("퍽!");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("갑자기 뒤통수에 둔탁하고 묵직한 느낌이 들었다.");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("어째서...");
        Function.GetUserInput();
        
        Clear();
        Function.TextDelay("CHAPTER 1", 250);
        Thread.Sleep(1000);
        WriteLine();
        Function.TextDelay("\t404 호",250);
        Function.GetUserInput();
        
        Clear();
    }
}