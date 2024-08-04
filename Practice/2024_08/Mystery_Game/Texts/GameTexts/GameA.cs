using static System.Console;
namespace Practice._2024_08.Mystery_Game.Texts.GameTexts;

public class GameA
{
    public void PrintText1()
    {
        Clear();
        Functions.TextDelay("퇴근 후 집으로 가는 길...");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("내일부터 한달 동안 휴가를 보내게 되었다.");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("여태 미뤄놨던 게임을 할 시간이다..");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("얼른 가서 씻고 컴퓨터를 켜야..");
        Functions.GetUserInput();
        
        Clear();
        Write("퍽!");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("갑자기 뒤통수에 둔탁하고 묵직한 느낌이 들었다.");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("어째서...");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("CHAPTER 1", 250);
        Thread.Sleep(1000);
        WriteLine();
        Functions.TextDelay("\t404 호",250);
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("여긴... 어디지...");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("차가운 나무 바닥.. 낡은 테이블과 깨진 거울, 다 헤져있는 침대가 놓여져있는 방..");
        Functions.GetUserInput();
        
        Clear();
        Functions.TextDelay("방 문은 굳게 닫혀있고 문에는 '404호'라고 쓰여져있다.");
        Functions.GetUserInput();
    }

    public void PrintMain()
    {
        Clear();
        WriteLine("CHAPTER 1, 404호");
        WriteLine("> 조사하기 ( 조사 )");
        WriteLine("> 소지품확인 ( 소지품 )");
    }
}