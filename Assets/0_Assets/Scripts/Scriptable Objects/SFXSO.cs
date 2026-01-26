using JetBrains.Annotations;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;

#region Enums
public enum SFX_Group
{
    Player,
    Enemy,
    UI,
    Obstacle
}

public enum SFX_Player
{
    Thruster,
    Low_Fuel_Warning,
    Fuel_Empty_Once,
    Fuel_Empty_GasLeak,
    Crash1, Crash2, Crash3,
}

#endregion


// public abstract class SFXAudioClipArray : ScriptableObject
// {
//     public SFX_Group sfxGroup;

//     public SFX_Player soundName;
//     public AudioClip audioClip;

//     public bool loop = false;
//     public bool playOnAwake = false;
//     //
//     public bool mute = false;
//     public bool bypassEffects;
//     public bool bypassListenerEffects;
//     public bool bypassReverbZones;

//     //
//     public int priority = 128;
//     //[Range]
//     public float volume;

//     public bool randomPitch;
//     public float pitch = 1f;

//     // controls the left-right balance of a sound, 
//     // moving it from full left (-1.0) to center (0.0) to full right (1.0)
//     public float panStereo = 0f;
    
//     // 2d = 0f, 3d = 1f;
//     public float spatialBlend = 1f;

//     public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic; //AudioRolloffMode.Linear;

//     public float minDistance = 5f;

//     // sound inaudible beyond this
//     public float maxDistance = 10f;

//     //
//     public bool ignoreListenerVolume;
//     public bool ignoreListenerPause;

// }

[System.Serializable]
public class SFXAudioClip : PlayerSFXAudioClip
{
    public bool playOnAwake;
    public float volume;
}


// must have [System.Serializable] to see at inspector
//[System.Serializable]
public class PlayerSFXAudioClip
{
    public SFX_Player soundName;
    public AudioClip audioClip;

    public bool loop = false;

    

}


// ===== =====
[CreateAssetMenu(fileName = "SFX_Player_ScriptableObject", menuName = "SO/Auidios/SFX_PlayerSO")]
public class SFX_PlayerSO : ScriptableObject
{   
    public SFX_Group sfx_Group;
    public AudioMixerGroup audioMixerGroup;
    
    public SFXAudioClip[] playerSFXAudioClipArray;
    

}

