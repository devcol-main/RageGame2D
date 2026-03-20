using UnityEngine;
using UnityEngine.Audio;
public enum BGM_Ambient_Name
{
    Amb1,Amb2,Amb3,Amb4,Amb5,Amb6,Amb7,
}


#region BGM_Ambient

[CreateAssetMenu(fileName = "BGMAmbient_SO", menuName = "SO/Audios/BGM_Ambient")]
public class BGMAmbientSO : ScriptableObject
{
    public AudioMixerGroup audioMixerGroup;
    public BGM_Ambient_Name soundName;
    public AudioClip audioClip;
    public bool loop = false;
    public bool playOnAwake = true;

    [Range(0f,1f)] 
    public float volume = 0.3f;
    public float pitch = 1f;
    public float panStereo = 0f;
    public float spatialBlend = 0f;


    void OnEnable()
    {
        audioMixerGroup = SoundManager.Instance.GetAudioMixer.FindMatchingGroups(
            GlobalString.AudioMixer.AMBIENT)[0];    
    }
}


#endregion
