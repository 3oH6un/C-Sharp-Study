using System.Runtime.CompilerServices;
namespace Practice._2024_08.Mystery_Game;

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
}