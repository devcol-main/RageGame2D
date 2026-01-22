using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//
using Utilities;


public class IngameUI : MonoBehaviour
{
   [SerializeField] private int score;
   [SerializeField] private TextMeshProUGUI ingameTimeText;

    private StopwatchTimer gameTimer;

    void Awake()
    {
        gameTimer = new StopwatchTimer("");
        
    }
    void Start()
    {
        Player.Instance.OnCoinPickup += Player_OnCoinPickup;
        GameManager.Instance.OnStateChanged += OnStateChaned;

        
    }

    private void OnStateChaned(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if (e.state == State.GameStart)
        {
            gameTimer.Start();
        }

        if (e.state == State.GameOver)
        {
            gameTimer.Stop();
        }
   
    }

    void OnEnable()
    {
        //Player.Instance.OnCoinPickup += Player_OnCoinPickup;
    }
    void OnDisable()
    {
        Player.Instance.OnCoinPickup -= Player_OnCoinPickup;
    }

    void FixedUpdate()
    {
        gameTimer.Tick(Time.fixedDeltaTime);

        ingameTimeText.text = Math.Round(gameTimer.GetTime(),2).ToString();
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
