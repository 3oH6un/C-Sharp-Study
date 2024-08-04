using System.Runtime.CompilerServices;
namespace Practice._2024_08.Mystery_Game;

/// <summary>
/// 게임 기능
/// </summary>
public class GameManager
{
    private Player _player;
    private int _gameCount;

    public GameManager(Player player)
    {
        _player = player;
    }
}