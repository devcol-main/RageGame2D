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
    private SFX sfx;

    protected override void Awake()
    {
        base.Awake();
        //audioListener.GetComponent<AudioListener>().enabled = false;
        audioListener.enabled = false;
    }

    void Start()
    {
        // Player.Instance.OnFuelPickup +=  OnFuelPickup;
        // Player.Instance.OnCoinPickup +=  OnCoinPickup;
        // Player.Instance.OnCrash      +=  OnCrash;

        bgm = FindAnyObjectByType<BGM>();
        sfx = FindAnyObjectByType<SFX>();

        //
        Debug.Log("Rough Start of Sound");
        PlayBGMMusic(BGM_Music_Name.Part1);

        PlayBGMAmbient(BGM_Ambient_Name.Amb2);

    }

    // off SoundManager Audio Listner on start (BC it's on Player)
    // on when player disabled
    public void SwitchAudioListener(bool isOn)
    {
        //audioSource.spatialBlend = (is2DSound == true) ? 0 : 1;
        audioListener.enabled = isOn; 
    }

    public void PlayBGMMusic(BGM_Music_Name musicName)
    {
        bgm.PlayBGMMusic(musicName);
    }

    //
    public void PlayBGMAmbient(BGM_Ambient_Name musicName)
    {
        float length = bgm.PlayBGMAmbient(musicName);
        Invoke("RandomPlayAmbient", length);
    }

    void RandomPlayAmbient()
    {
        int rand = Random.Range(0,7);
        Debug.Log("RandomPlayAmbient | rand: " + rand);
        PlayBGMAmbient((BGM_Ambient_Name)rand);
    }
}
