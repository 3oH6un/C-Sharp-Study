using Practice._2024_08.Mystery_Game.Entity;
using Practice._2024_08.Mystery_Game.Player;

namespace Practice._2024_08.Mystery_Game;

public class GameManager
{
    private EntityManager _entityManager;
    private PlayerManager _playerManager;

    public GameManager(EntityManager entityManager, PlayerManager playerManager)
    {
        _entityManager = entityManager;
        _playerManager = playerManager;
    }

    public void GetNote(int noteNumber)
    {
        if (noteNumber == 0)
            _entityManager.GetFounded(_entityManager.Places);
        else if (noteNumber == 1)
            _entityManager.GetFounded(_entityManager.Tools);
        else if (noteNumber == 2)
            _entityManager.GetFounded(_entityManager.Npcs);
    }
}