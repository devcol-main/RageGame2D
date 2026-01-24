using System;
using UnityEngine;


public class Player : MonoBehaviour
{    
    //
    public static Player Instance { get; private set; }

    // Event
    public event EventHandler OnCoinPickup;
    //public event EventHandler<OnLandedEventArgs> OnCoinPickup;
    //public class OnLandedEventArgs : EventArgs {public int score;}   
        
    public event EventHandler OnConsumingFuel;

    //public event EventHandler<OnLandedEventArgs> 

    // public event EventHandler<OnCollisionEventArgs> OnCollision;
    // public class OnCollisionEventArgs : EventArgs
    // {
        
    // }

    public Action OnCollision;
     

    
    //[Header("Player Stats")]
    
    public bool IsInfiniteFuel { get; private set; }
    public float MaxFuel { get; private set; }
    public float CurrentFuel { get; private set; }
    public float FuelConsumptionAmount { get; private set; }
    //public float brakingStrength = 10f;

    [Header("References")]
    [SerializeField] private Collider2D playerCol;




    void Awake()
    {
        playerCol = GetComponent<Collider2D>();
        

        Instance = this;

        IsInfiniteFuel = false;
        MaxFuel = 100f;
        FuelConsumptionAmount = 10f;

        // Set Player Stats
        CurrentFuel = MaxFuel;
        
    }

    void Start()
    {        
        GameManager.Instance.OnStateChanged += OnGameStateChanged;

    }

    private void OnGameStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        //Debug.Log($"Player OnGameStateChanged : {e} | {e.state}" );

        if (e.state == State.GameStart)
        {
            this.gameObject.SetActive(true);
            // Appear effects

        }
        else if (e.state == State.GameOver)
        {
            // cause error
            //GameOver();
        }
    }

    public void ConsumingFuel()
    {
        

        if (!IsInfiniteFuel)
        {
            CurrentFuel -= FuelConsumptionAmount * Time.fixedDeltaTime;
            // to prvent going to negative
            if (CurrentFuel <= 0)
            {
                CurrentFuel = 0;
            }

            OnConsumingFuel?.Invoke(this, EventArgs.Empty);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log($"OnCollisionEnter2D with {col}");

        //
        //GameManager.Instance.OnGameOver();
        if (!col.gameObject.TryGetComponent(out CollideableObject collideableObject))
        {
            //Debug.Log("!collideableObject");
            OnCollision?.Invoke();

            GameOver();

            GameManager.Instance.OnGameOver();
        }

        if (col.gameObject.TryGetComponent(out CollideableObject collideable))
        {
            //Debug.Log(" collideable");
        }

        //OnCollision?.Invoke();

        
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        // contect with fuel
        if (col.gameObject.TryGetComponent(out Fuel fuel))
        {         
            if (!IsInfiniteFuel || CurrentFuel < MaxFuel)
            {                
                CurrentFuel += fuel.GetFuel();

                if(CurrentFuel > MaxFuel)
                {
                    CurrentFuel = MaxFuel;
                }

                // destory only when player absorb fuel
                fuel.SelfDestruction();
            }                       
            
        }

        if(col.gameObject.TryGetComponent(out Coin coin))
        {
            //OnCoinPickup?.Invoke(this, EventArgs.Empty);
            OnCoinPickup?.Invoke((int)coin.GetScore(), EventArgs.Empty);

            
            coin.SelfDestruction();
        }

        
        
    }

    private void GameOver()
    {
        this.gameObject.SetActive(false);
        
    }


}
