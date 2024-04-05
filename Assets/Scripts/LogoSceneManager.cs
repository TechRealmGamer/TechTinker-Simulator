using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LogoSceneManager : MonoBehaviour
{
    public VideoPlayer studioLogo;
    public VideoPlayer gameLogo;

    Image image;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    void Start()
    {
        studioLogo.Prepare();
        gameLogo.Prepare();
        StartCoroutine(LoadStudioLogo());
        studioLogo.loopPointReached += LoadGameLogo;
        gameLogo.loopPointReached += LoadMainMenu;
    }

    IEnumerator LoadStudioLogo()
    {
        while (!studioLogo.isPrepared)
            yield return null;
        studioLogo.Play();
    }

    private void LoadGameLogo(VideoPlayer source)
    {
        studioLogo.gameObject.SetActive(false);
        gameLogo.Play();
        StartCoroutine(PlayingGameLogo());
    }

    private void LoadMainMenu(VideoPlayer source)
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator PlayingGameLogo()
    {
        while(gameLogo.isPlaying && ((gameLogo.frame/ (float) gameLogo.frameCount) * 100) <= 80f)
            yield return null;

        float alpha = 0;

        while(alpha < 1)
        {
            alpha += Time.deltaTime;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
