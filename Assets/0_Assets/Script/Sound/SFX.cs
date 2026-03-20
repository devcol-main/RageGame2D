using System;
using UnityEngine;

public class SFX : MonoBehaviour
{
    Player PI => Player.Instance;

    //[SerializeField] private SFX_PlayerSO sfx_PlayerSO;

    void Start()
    {
        // Player Instance
        PI.OnConsumingFuel  += Player_OnConsumingFuel;
        PI.OnFuelJustEmpted += Player_OnFuelJustEmpted;
        PI.OnFuelEmpty      += Player_OnFuelEmpty;

        //
    }
    private void Player_OnConsumingFuel(object sender, EventArgs e)
    {
        //
        // Debug.Log("from SFX.cs Player_OnConsumingFuel");
        


    }
    private void Player_OnFuelEmpty(object sender, EventArgs e)
    {
        // Debug.Log("from SFX.cs Player_OnFuelEmpty");
    }

    

    private void Player_OnFuelJustEmpted(object sender, EventArgs e)
    {
        //
        // Debug.Log("from SFX.cs Player_OnFuelJustEmpted");
        //
        //GameObject soundGameObject = new GameObject();
        //AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        
        // foreach (var sfx in sfx_PlayerSO.playerSFXAudioClipArray)
        // {
        //     if(sfx.soundName == SFX_Player.Fuel_Empty_Once)
        //     {
        //         audioSource.clip = sfx.audioClip;
        //         soundGameObject.name =  "_" + sfx.soundName.ToString();
        //         // soundGameObject.name = objectName + "_" + sfx.soundName.ToString();
        //         audioSource.PlayOneShot(sfx.audioClip);
        //     }
        // }

    }

    //private void SFXOneShot

}
