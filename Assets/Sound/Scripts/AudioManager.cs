using UnityEngine;
using System;
using UnityEditor;
public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;

    [SerializeField] private Sound bgm;
    [SerializeField] private Sound[] sounds;
    [SerializeField] private VolumeController volumeController;
    

    private void Awake()
    {
        
        if( instance != null )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        foreach( Sound sound in sounds )
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        Play(bgm);
    }
    public void Play(Sound sound)
    {
        
        Sound s = Array.Find(sounds, effect => effect.clip == sound.clip) ;
        if (s == null)
            return;
        s.source.Play();
    }
    public void SetEffectVolume(float volume)
    {
        foreach( Sound sound in sounds )
        {
            if (sound.type == Sound.Type.effect)
                sound.source.volume = volume;
        }
    }
    public void SetMusicVolume(float volume)
    {
        foreach( Sound sound in sounds )
        {
            if (sound.type == Sound.Type.music)
                sound.source.volume = volume;
        }
    }
}
