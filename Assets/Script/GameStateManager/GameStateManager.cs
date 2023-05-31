using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public static Action<GameStates> OnStateChange;

    public GameStates CurrentState;


    private void Start()
    {
        instance = this;
    }
    public void ChangeGameState(GameStates gs)
    {
        CurrentState = gs;
        OnStateChange?.Invoke(gs);
    }
}

public enum GameStates
{
    HomeScreen,
    GameOver,
    GamePlay,
}
