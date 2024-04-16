using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{
    public static UIManager INSTANCE;

    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonHoverClip;
    [SerializeField] private AudioClip buttonClickClip;

    [SerializeField] private GameObject pauseMenu;

    public TMP_Text errorMessageText;

    private void Awake()
    {
        INSTANCE = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!pauseMenu.activeSelf);
        }
    }


    public void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessageText.GetComponent<Animator>().Play("Display");
    }

    public void PauseGame(bool isPaused)
    {
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


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
