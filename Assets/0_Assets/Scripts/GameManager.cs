using System;
using UnityEditor.SearchService;
using UnityEngine;

//
using Utilities;

public class GameManager : Singleton<GameManager> 
{
    [SerializeField] private int score;

    [SerializeField] private StopwatchTimer gameTimer;

    void Awake()
    {
        base.Awake();

        gameTimer = new StopwatchTimer("");

        

        Debug.Log($"gameTimer.IsRunning: {gameTimer.IsRunning}");
        
    }
    void Start()
    {
        Player.Instance.OnCoinPickup += Player_OnCoinPickup;
        gameTimer.Start();

        Debug.Log($"gameTimer.IsRunning: {gameTimer.IsRunning}");
    }

    void OnEnable()
    {
        //Player.Instance.OnCoinPickup += Player_OnCoinPickup;
    }
    void OnDisable()
    {
        Player.Instance.OnCoinPickup -= Player_OnCoinPickup;
    }

    void Update()
    {
        gameTimer.Tick(Time.deltaTime);

        Debug.Log($"gameTimer.GetTime(): {gameTimer.GetTime()}");
    }


    private void Player_OnCoinPickup(object sender, EventArgs e)
    {
        Debug.Log($"sender: {sender}");
        AddScore((int)sender);
        
    }

    private void AddScore(int addScoreAmount)
    {
        score += addScoreAmount;
    }

}
