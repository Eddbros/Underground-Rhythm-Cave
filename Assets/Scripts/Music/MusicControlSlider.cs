using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicControlSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SliderControl (float sliderValue)
    {
        audioMixer.SetFloat("MVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SFXControl(float sliderValue)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }

}
    