using System.Collections.Generic;
using UnityEngine;


// public interface IPickUpItem
// {
//     public void SelfDestruction();
// }
public abstract class PickUpItem : MonoBehaviour //, IPickUpItem
{
    public abstract void SelfDestruction();
    public abstract void SelfDestructionEffect();


}


