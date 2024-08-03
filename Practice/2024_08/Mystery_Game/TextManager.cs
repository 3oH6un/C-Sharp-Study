using static System.Console;

namespace Practice._2024_08.Mystery_Game;

/// <summary>
/// 입출력 관리(인물 대사 등)
/// </summary>
public class TextManager
{
    private GameManager _gameManager;
    
    // 사용자 입력
    public string GetUserInput()
    {
        var userInput = ReadLine();
        userInput = userInput ?? "";
        return userInput.Trim();
    }

    public void StartGameText()
    {
        Clear();
        // Write("범죄는 ");
        // Thread.Sleep(1000);
        // Write("흔적을 ");
        // Thread.Sleep(1000);
        // Write("남긴다.");
        // Thread.Sleep(1000);
        Write("범죄는 ");
        Write("흔적을 ");
        Write("남긴다.");
        WriteLine("\nEnter키를 눌러 이야기를 시작하세요.");
        GetUserInput();
    }

    public void AddPlayerName()
    {
        while (true)
        {
            Clear();
            WriteLine("이름을 정해주세요.");
            string input = GetUserInput();
            WriteLine($"{input} 으로 결정하시겠습니까?");
            WriteLine("네 / 아니오");
            string select = GetUserInput();
            switch (select)
            {
                case "네" :
                    _gameManager.AddPlayer(input);
                    return;
                case "아니오" :
                    break;
                default:
                    WriteLine("네 / 아니오 로만 입력해주세요.");
                    break;
            }
        }
    }

    public void BeforeCase1()
    {
        Clear();
        WriteLine("2024년 8월의 여름, 선착장");
        GetUserInput();
        WriteLine("내가 하던 게임의 소모임에서 정모를 하다");
        Thread.Sleep(1500);
        WriteLine("운 좋게 별장을 빌리게 되어 다같이 여행을 가기로 했다.");
        GetUserInput();
        WriteLine("지금쯤 도착할 때가 되었는데..");
        GetUserInput();
        Clear();
        WriteLine("??? : 저 혹시..");
        GetUserInput();
        Clear();
        WriteLine("한쪽 손에는 캐리어.. 다른 한쪽 손에는 커피..");
        GetUserInput();
        Clear();
        WriteLine("누가봐도 여행가는 사람이다.");
        GetUserInput();
        Clear();
        WriteLine("");
    }

    public void DelayPrintTxt(string txt)
    {
        foreach (char c in txt)
        {
            Write(c);
            Thread.Sleep(100);
        }

        WriteLine();
    }
}