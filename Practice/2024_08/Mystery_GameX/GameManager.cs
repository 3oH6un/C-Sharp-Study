using System.Runtime.CompilerServices;
using Practice._2024_08.Mystery_GameX;

namespace Practice._2024_08.Mystery_GameX;

/// <summary>
/// 게임 기능 및 객체 관리
/// </summary>
public class GameManager
{
    // 필드에 플레이어 객체 및 게임 카운팅 선언
    private Player _player;
    private int _gameCount;

    // 기본 생성자에서 의존성 주입
    public GameManager(Player player)
    {
        _player = player;
    }

    public int PlayerSelect(string select)
    {
        if (select == "조사" || select == "조사하기")
            return 1;

        if (select == "확인" || select == "단서확인")
            return 2;

        else
            return 0;
    }
}