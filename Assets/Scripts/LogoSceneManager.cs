using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LogoSceneManager : MonoBehaviour
{
    public VideoPlayer studioLogo;
    public VideoPlayer gameLogo;

    void Start()
    {
        StartCoroutine(LoadStudioLogo());
        studioLogo.loopPointReached += LoadGameLogo;
        gameLogo.loopPointReached += LoadMainMenu;
    }

    IEnumerator LoadStudioLogo()
    {
        studioLogo.Prepare();
        while (!studioLogo.isPrepared)
        {
            yield return null;
        }
        studioLogo.Play();
    }

    private void LoadGameLogo(VideoPlayer source)
    {
        studioLogo.gameObject.SetActive(false);
        gameLogo.Play();
    }

    private void LoadMainMenu(VideoPlayer source)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
