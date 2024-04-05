using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonHoverClip;
    [SerializeField] private AudioClip buttonClickClip;

    [SerializeField] private GameObject loadingScreenBarSystem;

    private Animator animator;
    private AudioSource audioSource;

    private bool isAudioPanelOpen = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    #region UI Button Events

    public void StartGame()
    {
        loadingScreenBarSystem.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region Panel Animation Events

    public void OpenSettingsPanel()
    {
        animator.Play("OpenSettingsPanel");
        isAudioPanelOpen = true;
    }
    public void CloseSettingsPanel()
    {
        animator.Play("CloseSettingsPanel");
    }
    public void OpenCreditsPanel()
    {
        animator.Play("OpenCreditsPanel");
    }
    public void CloseCreditsPanel()
    {
        animator.Play("CloseCreditsPanel");
    }
    public void OpenAudioPanel()
    {
        if (isAudioPanelOpen)
            return;
        animator.Play("OpenAudioPanel");
    }
    public void OpenGraphicsPanel()
    {
        if (isAudioPanelOpen)
            animator.Play("OpenGraphicsPanel");
    }

    #endregion

    #region Button Audio Events

    public void ButtonOnHover()
    {
        audioSource.PlayOneShot(buttonHoverClip);
    }

    public void ButtonOnClick()
    {
        audioSource.PlayOneShot(buttonClickClip);
    }

    #endregion
}
