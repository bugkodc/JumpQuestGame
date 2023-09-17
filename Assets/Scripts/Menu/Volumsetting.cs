using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumsetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _Mixer;
    [SerializeField] private Slider _SliderMusic;
    [SerializeField] private Slider _SliderSFX;
    private void Start()
    {
        SetMusicvolume();
        SetSFXvolume();
    }
    public void SetMusicvolume()
    {
        float volume = _SliderMusic.value;
        _Mixer.SetFloat("music" , Mathf.Log10(volume)*20);
    }
    public void SetSFXvolume()
    {
        float volume = _SliderSFX.value;
        _Mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
