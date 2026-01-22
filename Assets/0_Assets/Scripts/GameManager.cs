using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

//


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

    //
    void Awake()
    {
        base.Awake();
        GameState = State.WatintingToStart;
    }

    void Start()
    {

    }

    public void OnGameStart()
    {
        SetState(State.GameStart);
        
    }

    public void OnGamePause()
    {
        
        SetState(State.GamePause);
    }

    public void OnGameOver()
    {
        
        SetState(State.GameOver);
    }

    private void SetState(State newState)
    {
        GameState = newState;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {state = GameState});
    }

    

}
