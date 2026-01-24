using UnityEngine;

public enum Mixer
{
    MainMixer,
    BGM,
    SFX,
    BGM_Music, BGM_Environment,
    SFX_Player, SFX_Menu, SFX_Enemy, SFX_Obstacle,


}
public class SoundManager : MonoBehaviour
{

    void Start()
    {
        // Player.Instance.OnFuelPickup +=  OnFuelPickup;
        // Player.Instance.OnCoinPickup +=  OnCoinPickup;
        // Player.Instance.OnCrash      +=  OnCrash;
    }
}
