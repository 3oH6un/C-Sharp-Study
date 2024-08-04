using static System.Console;
namespace Practice._2024_08.Mystery_Game.Texts;

public static class Functions
{
    // 디버그용 객체 선언 및 초기화
    private static readonly Debug Debug = new Debug();
    
    // 메시지 한글자씩 출력
    public static void TextDelay(string text, int delay = Debug.Delay)
    {
        foreach (char c in text)
        {
            Write(c);
            Thread.Sleep(delay);
        }
    }
    
    // 플레이어 입력
    public static string GetUserInput()
    {
        var userInput = ReadLine();
        userInput = userInput?.Trim() ?? string.Empty;
        return userInput.Trim();
    }
}