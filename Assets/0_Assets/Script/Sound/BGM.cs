using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    [Header("BGM_MUSIC")]
    [SerializeField] private AudioSource audioSourceMusic;

    [SerializeField] private BGMMusicSO[] bgmMusicSOArray;


    [Header("BGM_AMBIENT")]
    [SerializeField] private AudioSource audioSourceAmbient;
    [SerializeField] private BGMAmbientSO[] bgmAmbientSOArray;
    
    public float PlayBGMMusic(BGM_Music_Name musicName)
    {
        //bgmAudioSource.clip = bgmMusicSO.bgmMusicAudioClip.audioClip;
        //bgmAudioSource.Play();

        AudioSource bgmAudioSource = audioSourceMusic;

        float length = 0f;

        foreach (var bgm in bgmMusicSOArray)
        {
            if (bgm.soundName == musicName)
            {
                bgmAudioSource.outputAudioMixerGroup = bgm.audioMixerGroup;
                bgmAudioSource.clip = bgm.audioClip;

                bgmAudioSource.loop = bgm.loop;
                bgmAudioSource.playOnAwake = bgm.playOnAwake;

                bgmAudioSource.volume = bgm.volume;
                bgmAudioSource.pitch = bgm.pitch;
                bgmAudioSource.panStereo = bgm.panStereo;
                bgmAudioSource.spatialBlend = bgm.spatialBlend;

                bgmAudioSource.Play();

                length = bgm.audioClip.length;
            }
        }

        //Debug.Log("PlayBGMMusic");

        return length;
    }

    public float PlayBGMAmbient(BGM_Ambient_Name musicName)
    {
        //bgmAudioSource.clip = bgmMusicSO.bgmMusicAudioClip.audioClip;
        //bgmAudioSource.Play();

        AudioSource bgmAudioSource = audioSourceAmbient;

        float length = 0f;

        foreach (var bgm in bgmAmbientSOArray)
        {
            if (bgm.soundName == musicName)
            {
                bgmAudioSource.outputAudioMixerGroup = bgm.audioMixerGroup;
                bgmAudioSource.clip = bgm.audioClip;

                bgmAudioSource.loop = bgm.loop;
                bgmAudioSource.playOnAwake = bgm.playOnAwake;

                bgmAudioSource.volume = bgm.volume;
                bgmAudioSource.pitch = bgm.pitch;
                bgmAudioSource.panStereo = bgm.panStereo;
                bgmAudioSource.spatialBlend = bgm.spatialBlend;

                bgmAudioSource.Play();

                

                length = bgm.audioClip.length;
            }
        }

        //Debug.Log("PlayBGMMusic");

        return length;
    }


}
