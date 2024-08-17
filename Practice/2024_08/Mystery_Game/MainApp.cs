using Practice._2024_08.Mystery_Game.Entity;
using Practice._2024_08.Mystery_Game.Player;
using Practice._2024_08.Mystery_Game.Text;

namespace Practice._2024_08.Mystery_Game;

public class MainApp
{
    static IoManager _ioManager = new IoManager();
    static EntityManager _entityManager = new EntityManager();
    static PlayerManager _playerManager = new PlayerManager();
    static GameManager _gameManager = new GameManager(_entityManager, _playerManager);

    public static void Main(string[] args)
    {
        GameStart();

        while (true)
        {
        }
    }

    public static void GameStart()
    {
        _ioManager.PrintWithDelay(Texts.Start[0], 200);
        _ioManager.WaitForSeconds(1);
        _ioManager.PrintText(Texts.Start[1]);
        _ioManager.PrintText(Texts.Start[2]);
        _ioManager.PrintText(Texts.Start[3]);
    }
}