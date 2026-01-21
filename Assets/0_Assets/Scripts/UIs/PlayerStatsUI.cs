using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    
    [Header("Reference")]
    [SerializeField] private TextMeshProUGUI fuelAmountText;
    [SerializeField] private Image fuelImage;

    [Header("Colors")]
    [SerializeField] private Color greenColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color redColor;
    
    void Start()
    {
        Player.Instance.OnConsumingFuel += Player_OnConsumingFuel;

        fuelAmountText.text = Player.Instance.CurrentFuel + " / " + Player.Instance.MaxFuel;
    }

    private void Player_OnConsumingFuel(object sender, EventArgs e)
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

  


}
