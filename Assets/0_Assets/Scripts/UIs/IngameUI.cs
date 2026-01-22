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

   [Header("Buttons")]
   [SerializeField] private Button restartButton;

    private StopwatchTimer gameTimer;

    void Awake()
    {
        gameTimer = new StopwatchTimer("");

        // Buttons
        restartButton.onClick.AddListener(() =>  { SceneLoader.Instance.RestartScene();});
        
    }
    void Start()
    {
        Player.Instance.OnCoinPickup += Player_OnCoinPickup;
        GameManager.Instance.OnStateChanged += OnStateChaned;


        if (State.GameStart == GameManager.Instance.GameState)
        {
            gameTimer.Start();
        }
        
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

        DisplayingTime();
        

        

    }

    private void DisplayingTime()
    {
        var tempTotalTime = gameTimer.GetTime();
        var min = (int)(tempTotalTime / 60);

        var tempSec = Math.Round(tempTotalTime) % 60;

        if (0 < min)
        {
            ingameTimeText.text = min.ToString() + ":" + tempSec;
        }
        else
        {
            ingameTimeText.text = Math.Round(gameTimer.GetTime()).ToString();
        }
        

        //ingameTimeText.text = min.ToString() + ":" + sec.ToString();
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
