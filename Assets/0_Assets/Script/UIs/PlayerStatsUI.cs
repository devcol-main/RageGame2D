using System;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    
    [Header("Fuel")]
    [SerializeField] private TextMeshProUGUI fuelAmountText;
    [SerializeField] private Image fuelImage;

    [SerializeField] private Color greenColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color redColor;

    [Header("Speed")]
    [SerializeField] private TextMeshProUGUI speedText;

    //[Header("Player")][SerializeField] 
    private PlayerController playerController;

    void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Start()
    {
        Player.Instance.OnConsumingFuel += FuelChange;

        //
        Player.Instance.OnFuelPickup += FuelChange;
        Player.Instance.OnFuelSpaceStation += FuelChange;


        fuelAmountText.text = Player.Instance.CurrentFuel + " / " + Player.Instance.MaxFuel;

        

        //playerController = GetComponent<PlayerController>();   

        if(null == playerController)
        {
            playerController = FindAnyObjectByType<PlayerController>();
            Debug.LogError("null == playerController from " + this.name);
        }
        

    }

    private void FuelChange(object sender, EventArgs e)
    {
        // image
        float fuelNormalize = (Player.Instance.CurrentFuel / Player.Instance.MaxFuel);    

        if (0.6 < fuelNormalize)
        {
            fuelAmountText.color = greenColor;
            fuelImage.color      = greenColor;
        }
        else if (0.6f >= fuelNormalize && 0.3f < fuelNormalize)
        {
            fuelAmountText.color = yellowColor;
            fuelImage.color      = yellowColor;
            
        } 
        else //if (0.3f >= fuelNormalize)
        {
            fuelAmountText.color = redColor;
            fuelImage.color      = redColor;
        }

        fuelImage.fillAmount = fuelNormalize;
        fuelAmountText.text = Mathf.Round(Player.Instance.CurrentFuel) + " / " + Player.Instance.MaxFuel;
    }

    void LateUpdate()
    {
        speedText.text = playerController.GetPlayerCurrentSpeed().ToString("F1");

                
        //Debug.Log("rb.totalForce: " + rb.linearVelocity.y);
        //Debug.Log("rb.totalForce: " + (Mathf.Abs(rb.linearVelocity.y) * 10 ).ToString("F1"));
        //  return (Mathf.Abs(rb.linearVelocity.y) * 10 );
    }



}
