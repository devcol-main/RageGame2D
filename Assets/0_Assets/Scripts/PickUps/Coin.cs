using UnityEngine;

public class Coin : PickUpItem
{
    [SerializeField] private int score = 10;
    public float GetScore () => score;

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
