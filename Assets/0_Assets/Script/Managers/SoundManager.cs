using UnityEngine;
using UnityEngine.Audio;


public enum Mixer
{
    MainMixer,
    BGM,
    SFX,
    BGM_Music, BGM_Environment,
    SFX_Player, SFX_Menu, SFX_Enemy, SFX_Obstacle,


}
public class SoundManager : Singleton<SoundManager> 
{

    [SerializeField] private AudioMixer audioMixer;

    public AudioMixer GetAudioMixer { get { return audioMixer; } }

    [SerializeField] private AudioListener audioListener;
    
    //
    private BGM bgm;

    void Awake()
    {
        //audioListener.GetComponent<AudioListener>().enabled = false;
        audioListener.enabled = false;
    }



    void Start()
    {
        // Player.Instance.OnFuelPickup +=  OnFuelPickup;
        // Player.Instance.OnCoinPickup +=  OnCoinPickup;
        // Player.Instance.OnCrash      +=  OnCrash;

        bgm = FindAnyObjectByType<BGM>();

        PlayBGM(BGM_Music_Name.Part1);

    }

    public void SwitchAudioListener(bool isOn)
    {
        //audioSource.spatialBlend = (is2DSound == true) ? 0 : 1;
        audioListener.enabled = isOn; 
    }

    public void PlayBGM(BGM_Music_Name musicName)
    {
        bgm.PlayBGMMusic(musicName);
    }
}
