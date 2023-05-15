using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        instance = this;   
    }
    private void Start()
    {
        UpdateGameState(GameState.MainScreen);
    }
    public void UpdateGameState(GameState newState) {
        State = newState;
        switch (newState){
            case GameState.MainScreen:
                break;
            case GameState.GamePlayScreen:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }
        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    MainScreen,
    GamePlayScreen,
    GameOver
}