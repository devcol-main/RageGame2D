using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

//
using Utilities;

public enum State
{
    WatintingToStart,
    GameStart,
    GamePause,
    GameOver,
    
}


public class GameManager : Singleton<GameManager> 
{
    // EventHandlers
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    //
    public State GameState { get; private set; }

    void Start()
    {
            
    }

    public void OnGameStart()
    {
        GameState = State.GameStart;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {state = GameState});
    }

    public void OnGamePause()
    {
        GameState = State.GamePause;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {state = GameState});
    }

    public void OnGameOver()
    {
        GameState = State.GameOver;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {state = GameState});
    }

    

}
