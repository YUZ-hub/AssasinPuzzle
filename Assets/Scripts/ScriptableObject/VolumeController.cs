using UnityEngine;


[CreateAssetMenu(fileName ="VolumeController", menuName ="VolumeController")]
public class VolumeController : ScriptableObject
{
    [SerializeField]
    [Range(0f,1f)]
    public float effectVolume, musicVolume;

    public void SetEffectVolume(float volume)
    {
        effectVolume = volume;
        AudioManager.instance.SetEffectVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        AudioManager.instance.SetMusicVolume(volume);
    }
}
