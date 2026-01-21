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

    
    //[Header("Player Stats")]
    public bool IsInfiniteFuel { get; private set; }
    public float MaxFuel { get; private set; }
    public float CurrentFuel { get; private set; }
    public float FuelConsumptionAmount { get; private set; }
    //public float brakingStrength = 10f;

    [Header("References")]
    [SerializeField] private Collider2D col;



    void Awake()
    {
        col = GetComponent<Collider2D>();   

        Instance = this;

        IsInfiniteFuel = false;
        MaxFuel = 100f;
        FuelConsumptionAmount = 10f;

        // Set Player Stats
        CurrentFuel = MaxFuel;
        
    } 

    public void ConsumingFuel()
    {
        if (!IsInfiniteFuel)
        {
            CurrentFuel -= FuelConsumptionAmount * Time.fixedDeltaTime;
            OnConsumingFuel?.Invoke(this, EventArgs.Empty);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    
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


}
