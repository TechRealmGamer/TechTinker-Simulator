using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    [Header("Settings Panels")]
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject graphicsPanel;

    [Header("Audio Settings")]
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    [Header("Graphics Settings")]
    [SerializeField] private int resolutionIndex;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    


    
}
