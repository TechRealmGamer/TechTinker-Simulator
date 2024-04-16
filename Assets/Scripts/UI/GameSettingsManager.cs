using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettingsManager : MonoBehaviour
{
    [Header("Settings Panels")]
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject graphicsPanel;

    [Header("Audio Settings")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Graphics Settings")]
    [SerializeField] private int resolutionIndex;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void SetMasterVolume(Slider slider)
    {
        audioMixer.SetFloat("volumeMaster", slider.value);
    }

    public void SetMusicVolume(Slider slider)
    {
        audioMixer.SetFloat("volumeBGM", slider.value);
    }

    public void SetSFXVolume(Slider slider)
    {
        audioMixer.SetFloat("volumeSFX", slider.value);
    }

    public void SetUIVolume(Slider slider)
    {
        audioMixer.SetFloat("volumeUI", slider.value);
    }
}
