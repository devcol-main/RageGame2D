using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fuelAmountText;
    [SerializeField] private Image fuelImage;

    void Start()
    {
        Player.Instance.OnConsumingFuel += Player_OnConsumingFuel;

        fuelAmountText.text = Player.Instance.CurrentFuel + " / " + Player.Instance.MaxFuel;
    }

    private void Player_OnConsumingFuel(object sender, EventArgs e)
    {
        fuelAmountText.text = Mathf.Round(Player.Instance.CurrentFuel) + " / " + Player.Instance.MaxFuel;

        float fuelNormalize = (Player.Instance.CurrentFuel / Player.Instance.MaxFuel);    

        fuelImage.fillAmount = fuelNormalize;
    }

  


}
