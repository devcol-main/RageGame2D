using UnityEngine;

public class Fuel : PickUpItem
{
    [SerializeField] private float fuelAmount = 100f;

    public float GetFuel () => fuelAmount;

    public override void SelfDestruction()
    {
        SelfDestructionEffect();
        // sound

        //
        Destroy(this.gameObject);
    }

    public override void SelfDestructionEffect()
    {
        
    }
}

