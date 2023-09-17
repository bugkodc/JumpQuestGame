using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Audiomanager : MonoBehaviour
{
    [Header("AUDIO_SOUND")]
    [SerializeField]  AudioSource _MusicSound;
    [SerializeField]  AudioSource _SFXSound;
    [Header("AUDIO_CLIP")]
    public AudioClip _background;
    public AudioClip _jump;
    public AudioClip _hit;
    public AudioClip _checkpoint;
    public AudioClip _winner;
    public AudioClip _tele;
    public AudioClip _eff;
    private void Start()
    {
        _MusicSound.clip = _background;
        _MusicSound.Play();  
    }
    public void PlaySFX(AudioClip _clip)
    {
        _SFXSound.PlayOneShot(_clip);
    }
}
