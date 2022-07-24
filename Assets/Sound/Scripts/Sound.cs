using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AudioManager")]
[CreateAssetMenu(fileName ="New Sound",menuName ="Sound")]
public class Sound : ScriptableObject
{
    public enum Type { effect, music };
    [SerializeField] internal AudioClip clip;

    [SerializeField]
    [Range(0f,1f)]
    internal float volume = 1;

    [SerializeField]
    internal Type type;

    [SerializeField]
    [Range(-3f,3f)]
    internal float pitch = 1;

    [SerializeField]
    internal bool loop;

    internal AudioSource source;
    internal int index;
}
