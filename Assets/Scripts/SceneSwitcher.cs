using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName, System.Action onLoaded = null)
    {
        StartCoroutine(LoadSceneAsync(sceneName, onLoaded));
    }

    private IEnumerator LoadSceneAsync(string sceneName, System.Action onLoaded)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        yield return asyncOperation;

        onLoaded?.Invoke();
    }
}