using UnityEngine;
using UnityEngine.Audio;

public enum SFX_Group
{
    Player,
    Enemy,
    UI,
    Obstacle
}

[CreateAssetMenu(fileName = "SFX_", menuName = "Audios/SFX")]
public class SFXSO : ScriptableObject
{
    
    // audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups(audioMixerGroupPath)[0];
    //     audioSource.playOnAwake = false;
    //     audioSource.loop = true;

#region Config
    public SFX_Group sfx_Group;
    public AudioClip[] audioClips;

    public bool loop = false;
    //[Range]
    public float volume;

    public bool randomPitch;
    public float pitch;


#endregion
    // [Header("Menu SFX")]
    // public AudioClip[] menu;

    // [Header("Player SFX")]
    // //[SerializeField]
    // public AudioClip[] thruster;
    // public AudioClip[] crash;
    // public AudioClip[] fuel;


    // [Header("Enemy SFX")]
    // public AudioClip[] enemy;
    // [Header("Obstacle SFX")]
    // public AudioClip[] obstacle;

    public void Initiate()
    {
        
    }

}
