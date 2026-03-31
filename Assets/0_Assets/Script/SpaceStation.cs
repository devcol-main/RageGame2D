using TMPro;
using UnityEngine;

// rotate with dot tween

public class SpaceStation : MonoBehaviour
{
    // max fuel
    [Header("Fuel")]
    [SerializeField] private float fuelAmount = 100f;
    public float GetFuel() => fuelAmount;

    [Header("Entrance")]
    [SerializeField] private float entranceSpeedLimit = 0.1f; // 0.07 ~ 0.15
    public float GetEntranceSpeedLimit() => entranceSpeedLimit;

    [SerializeField] private GameObject entranceSpeedLimitText;

    //
    [Header("Station Movement")]
    [SerializeField] private float rotationSpeed = 10f;
    //
    [Header("Col Arrays")]
    [SerializeField] private Collider2D[] colArray;

    void Start()
    {
        entranceSpeedLimitText.GetComponent<TextMeshPro>().text = (entranceSpeedLimit * 10f).ToString();
    }

    public void DockingSuccess()
    {
        Debug.Log("Docking Success");
        // effect

        // disableCollider
        foreach (Collider2D col in colArray)
        {
            col.enabled = false;
        }

        // stop movement

        // fueliing (max fuel)
        Player.Instance.FuelFromSpaceStation();
        // 
    }

    public void DockingFailure()
    {
        Debug.Log("!!! DockingFailure");
        // effect
    }




}
