using UnityEngine;

// rotate with dot tween

public class SpaceStation : MonoBehaviour
{
    // max fuel
   [SerializeField] private float fuelAmount = 100f;
   [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private Collider2D[] colArray;
    public float GetFuel () => fuelAmount;



    public void DockingSuccess()
    {
        // effect

        // disableCollider
        foreach (Collider2D col in colArray)
        {
            col.enabled = false;
        }

        // stop movement

        // fueliing (max fuel)
    }



    
}
