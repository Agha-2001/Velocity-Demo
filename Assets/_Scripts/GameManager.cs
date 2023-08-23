using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [System.Serializable]
    public enum GameState
    {
        Playing,
        Paused,
        MainMenu,
        Quitting
    }

    GameState current
    {
        get
        {
            return current;
        }
        set
        {
            current = value;
            ImplementGameState(current);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        current = GameState.MainMenu;
    }

    public void SetGameState(GameState state)
    {
        current = state;
    }

    private void ImplementGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                // Something.
                break;

            case GameState.Playing:
                // Something.
                break;

            case GameState.Paused:
                // Something.
                break;

            case GameState.Quitting:
                // Something
                break;

            default:

                break;
        }
    }
}
