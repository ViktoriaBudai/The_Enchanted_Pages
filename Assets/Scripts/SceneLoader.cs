using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delayBeforeLoading = 2f; // Adjust the delay as needed

    public void LoadSceneWithSound(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene(sceneName);
    }
}