using static System.Console;

namespace Practice._2024_08.Mystery_Game.Text;

public class IoManager
{
    // 디버그용 객체 선언 및 초기화
    private readonly Debug _debug = new Debug();

    public void WaitForSeconds(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }
    
    public void PrintText(string text)
    {
        Clear();
        WriteLine(text);
        GetUserInput();
    }

    // 메시지 한글자씩 출력
    public void PrintWithDelay(string text, int delay = Debug.Delay)
    {
        foreach (char c in text)
        {
            Write(c);
            Thread.Sleep(delay);
        }

        WriteLine();
    }

    // 플레이어 입력
    public string GetUserInput()
    {
        var userInput = ReadLine();
        userInput = userInput?.Trim() ?? string.Empty;
        return userInput.Trim();
    }
}