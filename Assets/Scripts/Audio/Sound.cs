using System;
using UnityEngine;

[System.Serializable]
public sealed class Sound
{
    [SerializeField] private string _name;
    [SerializeField] private AudioClip _clip;

    [SerializeField] private Boolean _loop;

    [Range(0f, 1f)]
    [SerializeField] private Single _volume;

    [Range(1f, 3f)]
    [SerializeField] private Single _pitch;

    AudioSource _audioSource;

    public Sound()
    {
        _loop = false;
        _volume = 1.0f;
        _pitch = 1.0f;
    }

    public AudioSource AudioSource {
        get { return _audioSource; }
        set { _audioSource = value; }
    }

    public string Name { get { return _name; } }
    public AudioClip Clip { get { return _clip; } }
    public Single Volume { get { return _volume; } }
    public Single Pitch { get { return _pitch; } }
    public Boolean Loop { get { return _loop; } }
}
