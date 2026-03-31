using TMPro;
using UnityEngine;
using PrimeTween;

// rotate with dot tween

public class SpaceStation : MonoBehaviour
{
    //[Header("Save")]
    // pos, flag
    //[SerializeField] private  

    // max fuel
    [Header("Fuel")]
    [SerializeField] private float fuelAmount = 100f;
    [SerializeField] private float fuelDuration = 3f;

    [Header("Entrance")]
    [SerializeField] private float entranceSpeedLimit = 0.1f; // 0.07 ~ 0.15
    public float GetEntranceSpeedLimit() => entranceSpeedLimit;

    [SerializeField] private GameObject entranceSpeedLimitText;

    //
    [Header("Station Movement")]
    
    [SerializeField] private bool rotatingStation = true;
    [Range(500f,50f)]
    [SerializeField] private float rotateDuration = 100f;
    //
    [Header("Col Arrays")]
    [SerializeField] private Collider2D[] colArray;

    //
    
    private Tween rotatingTween;

    void Start()
    {
        entranceSpeedLimitText.GetComponent<TextMeshPro>().text = (entranceSpeedLimit * 10f).ToString();

        if(rotatingStation)
            TweeningRotation();
    }

    private void TweeningRotation()
    {
        // Rotate 'transform' around the z-axis by 360 degrees in 1 second 
        rotatingTween = Tween.EulerAngles(this.transform, 
            startValue: Vector3.zero, endValue: new Vector3(0,0,360), duration: rotateDuration, 
            ease: Ease.Linear, cycles: -1);
    }

    //

    public void DockingSuccess()
    {
        Debug.Log("Docking Success");
        // effect

        // disableCollider
        foreach (Collider2D col in colArray)
        {
            col.enabled = false;
        }

        //
        Player.Instance.SetParentObject(this.transform);
        Player.Instance.InactivePlayerController();

        //

        // fueliing (max fuel)
        Player.Instance.FuelFromSpaceStation();
        // 

        // stop rotating after fueling
        //rotatingTween.Stop();

        Invoke("Complete", fuelDuration);

        //StartCoroutine();
    }

    private void Complete()
    {
        rotatingTween.Stop();
        Player.Instance.ReleaseParentObject();
        Player.Instance.ActivePlayerController();

    }



    public void DockingFailure()
    {
        Debug.Log("!!! DockingFailure");
        // effect
    }




}
