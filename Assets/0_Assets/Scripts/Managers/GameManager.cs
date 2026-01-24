using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

//


public enum State
{
    WatintingToStart,
    GameStart,
    GamePause,
    GameResume,
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

    public event EventHandler OnPauseGame;
    public event EventHandler OnResumeGame;

    //
    public State GameState { get; private set; }

    //
    void Awake()
    {
        base.Awake();
        //GameState = State.WatintingToStart;
        GameState = State.GameStart;

        // just to make sure
        Time.timeScale = 1f;
    }

    void Start()
    {
        InputReader.Instance.OnMenuButtonPressed += OnMenuButtonPressed;
    }

    private void OnMenuButtonPressed(object sender, EventArgs e)
    {
        PauseResumeGame();
    }

    public void PauseResumeGame()
    {
        if (Time.timeScale == 1f)
        {
            PauseGame();
        }
        else if (Time.timeScale == 0f)
        {
            ResumeGame();
        }
    }

    public void GameStart()
    {
        SetState(State.GameStart);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SetState(State.GamePause);

        OnResumeGame?.Invoke(this, EventArgs.Empty);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        SetState(State.GamePause);

        OnPauseGame?.Invoke(this, EventArgs.Empty);
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

    public void OnApplicationQuit()
    {
        Debug.Log("from GM: OnApplicationQuit");

        Application.Quit();
    }



}
