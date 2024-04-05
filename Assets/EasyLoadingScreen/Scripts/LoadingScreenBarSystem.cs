using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem : MonoBehaviour {

    [SerializeField] private float minTimeToLoad = 3f;
    public GameObject bar;
    public Text loadingText;
    AsyncOperation async;

    private void OnEnable()
    {
        StartCoroutine(Loading());
    }

    // Activate the scene 
    IEnumerator Loading ()
    {
        var startTimeStamp = Time.time;
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        async.allowSceneActivation = false;

        while(Time.time - startTimeStamp < minTimeToLoad)
        {
            bar.transform.localScale = new Vector3((Time.time - startTimeStamp) / minTimeToLoad, 0.9f, 1);
            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
            yield return null;
        }

        // Continue until the installation is completed
        while (async.isDone == false)
        {
/*
            bar.transform.localScale = new Vector3(async.progress,0.9f,1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
*/
            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
