using System;

using UnityEngine;
using UnityEngine.Audio;

#region ENUMS

public enum BGM_Music_Name
{
    Menu,
    Part1,
    Part2,
    Part3,
}



#endregion

// ==

#region  BGM_Music

// [System.Serializable]
// public class BGMMusicAudioClip
// {
//     public AudioMixerGroup audioMixerGroup;
//     public BGM_Music_Name soundName;
//     public AudioClip audioClip;
//     public bool loop = true;
//     public bool playOnAwake = true;

//     [Range(0f,1f)] 
//     public float volume = 0.5f;
//     public float pitch = 1f;
//     public float panStereo = 0f;

//     public float spatialBlend = 0f;
// }


[CreateAssetMenu(fileName = "BGMMusic_SO", menuName = "SO/Audios/BGM_Music")]
public class BGMMusicSO : ScriptableObject
{
    public AudioMixerGroup audioMixerGroup;
    public BGM_Music_Name soundName;
    public AudioClip audioClip;
    public bool loop = true;
    public bool playOnAwake = true;

    [Range(0f,1f)] 
    public float volume = 0.5f;
    public float pitch = 1f;
    public float panStereo = 0f;

    public float spatialBlend = 0f;


    void OnEnable()
    {
        audioMixerGroup = SoundManager.Instance.GetAudioMixer.FindMatchingGroups(
            GlobalString.AudioMixer.MUSIC)[0];    
    }
}
#endregion

// ===

