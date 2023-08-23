using UnityEngine;

public enum GameType { Normal, SpeedRun}

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameType gameType;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Sets the game type from our selections
    public void SetGameType(GameType _gameType)
    {
        gameType = _gameType;
    }

    //To toggle between speedrun on or off
    public void ToggleSpeedRun(bool _speedrun)
    {
        if (_speedrun)
            SetGameType(GameType.SpeedRun);
        else
            SetGameType(GameType.Normal);
    }
}
