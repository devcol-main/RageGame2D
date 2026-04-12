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
    public event EventHandler OnFuelPickup;

    public event EventHandler OnConsumingFuel;

    public event EventHandler OnFuelSpaceStation;

    // only once
    public event EventHandler OnFuelJustEmpted;
    
    // every time when player tries to use fuel on empty fuel
    public event EventHandler OnFuelEmpty;

    //public event EventHandler<OnLandedEventArgs> 

    // public event EventHandler<OnCollisionEventArgs> OnCollision;
    // public class OnCollisionEventArgs : EventArgs
    // {
        
    // }

    
    public Action OnCrash;
    //public Action On
    
    //[Header("= Player Stats =")]
    public bool IsInfiniteFuel { get; private set; }
    public float MaxFuel { get; private set; }
    public float CurrentFuel { get; private set; }
    public float FuelConsumptionAmount { get; private set; }
    //public float brakingStrength = 10f;

    // H2O
    public float MaxH2OTank { get; private set; }
    public float CurrentH2O { get; private set; }
    
    public float H2OConsumptionAmountPerSec { get; private set; } 

    //

    [Header("References")]
    [SerializeField] private Collider2D playerCol;
    [SerializeField] private PlayerController playerController;

    
    

// ===== =====
    [Header("=== FOR DEBUG ===")]
    [SerializeField] private bool setInfiniteFuel;

    

    // ===== =====
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

        SoundManager.Instance.SwitchAudioListener(false);    

    }

    void Update()
    {
        IsInfiniteFuel = setInfiniteFuel;
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

    public bool ConsumingFuel()
    {
        if(0 >= CurrentFuel && !IsInfiniteFuel)
        {
            OnFuelEmpty?.Invoke(this, EventArgs.Empty);
            return false;
        }


        if (!IsInfiniteFuel)
        {

            CurrentFuel -= FuelConsumptionAmount * Time.fixedDeltaTime;
            //OnConsumingFuel?.Invoke(this, EventArgs.Empty);
            
            // to prvent going to negative
            if (0 >= CurrentFuel)
            {
                CurrentFuel = 0;
                //OnFuelJustEmpted?.Invoke(this, EventArgs.Empty);
            }

            OnConsumingFuel?.Invoke(this, EventArgs.Empty);

        }

        return true;
    }

    // allow once to use even it's amount exceed currentfuel
    public bool FixedConsumingFuel(float amount)
    {
         if(0 >= CurrentFuel && !IsInfiniteFuel)
        {
            OnFuelEmpty?.Invoke(this, EventArgs.Empty);
            return false;
        }

        if (!IsInfiniteFuel)
        {

            CurrentFuel -= amount;
            //OnConsumingFuel?.Invoke(this, EventArgs.Empty);
            
            // to prvent going to negative
            if (0 >= CurrentFuel)
            {
                CurrentFuel = 0;
                //OnFuelJustEmpted?.Invoke(this, EventArgs.Empty);
            }

            OnConsumingFuel?.Invoke(this, EventArgs.Empty);

        }

        return true;


    }

    public void FuelFromSpaceStation()
    {
        Debug.Log("Player : FullFillFuel");
        CurrentFuel = MaxFuel;

        OnFuelSpaceStation?.Invoke(this, EventArgs.Empty);
        

    }

    //
    public void SetParentObject(Transform parent)
    {
        this.transform.SetParent(parent);
    }

    public void ReleaseParentObject()
    {
        this.transform.SetParent(null);
    }

    //
    public void InactivePlayerController()
    {
        playerController.enabled = false;
    }

    public void ActivePlayerController()
    {
        playerController.enabled=true;
    }



    //

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log($"OnCollisionEnter2D with {col}");

        //
        //GameManager.Instance.OnGameOver();
        if (!col.gameObject.TryGetComponent(out CollideableObject collideableObject))
        {
            //Debug.Log("!collideableObject");
            OnCrash?.Invoke();

            GameOver();

            //GameManager.Instance.OnGameOver();
        }

        if (col.gameObject.TryGetComponent(out CollideableObject collideable))
        {
            Debug.Log(" collideable");
        }

        //OnCollision?.Invoke();

        
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        #region  Fuel
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

                OnFuelPickup?.Invoke(this, EventArgs.Empty);
            }                       
            
        }


        #endregion


        if(col.gameObject.TryGetComponent(out Coin coin))
        {
            //OnCoinPickup?.Invoke(this, EventArgs.Empty);
            OnCoinPickup?.Invoke((int)coin.GetScore(), EventArgs.Empty);

            
            coin.SelfDestruction();
        }

        
        
    }

    private void GameOver()
    {
        SoundManager.Instance.SwitchAudioListener(true);        

        this.gameObject.SetActive(false);
        
    }


}
