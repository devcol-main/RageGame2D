using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    [Header("BGM_MUSIC")]
    [SerializeField] private AudioSource audioSourceMusic;

    [SerializeField] private BGM_Music_SO[] bgmMusicSOArray;


    [Header("BGM_AMBIENT")]
    [SerializeField] private AudioSource audioSourceAmbient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float PlayBGMMusic(BGM_Music_Name musicName)
    {
        //audioSourceMusic.clip = bgmMusicSO.bgmMusicAudioClip.audioClip;
        //audioSourceMusic.Play();

        float length = 0f;

        foreach (var bgm in bgmMusicSOArray)
        {
            if (bgm.soundName == musicName)
            {
                audioSourceMusic.outputAudioMixerGroup = bgm.audioMixerGroup;
                audioSourceMusic.clip = bgm.audioClip;

                audioSourceMusic.loop = bgm.loop;
                audioSourceMusic.playOnAwake = bgm.playOnAwake;

                audioSourceMusic.volume = bgm.volume;
                audioSourceMusic.pitch = bgm.pitch;
                audioSourceMusic.panStereo = bgm.panStereo;
                audioSourceMusic.spatialBlend = bgm.spatialBlend;

                audioSourceMusic.Play();

                length = bgm.audioClip.length;
            }
        }

        //Debug.Log("PlayBGMMusic");

        return length;
    }


}
