using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private string sceneToLoad;

	[SerializeField] bool preLoadScene = false;
	AsyncOperation scenePreLoad;

    private void Start()
    {
		if (!preLoadScene) return;

		scenePreLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
		scenePreLoad.allowSceneActivation = false;
		scenePreLoad.priority = 19;
    }

    public void Load()
    {
		if (sceneToLoad == string.Empty)
		{
			Debug.LogWarning("Tried to load scene without a name.");
			return;
		}
		
        SceneManager.LoadScene(sceneToLoad);
    }
	
    public void Load(string sceneName)
    {
		if (sceneName == string.Empty)
		{
			Debug.LogWarning("Tried to load scene without a name.");
			return;
		}

		if(preLoadScene) scenePreLoad.allowSceneActivation = true;

		while (!scenePreLoad.isDone) { /*wait...*/ }

        SceneManager.LoadScene(sceneName);
    }
	
	// Delay in seconds
    public void LoadWithDelay(float delay)
    {
        StartCoroutine(LoadWithDelayCoroutine(sceneToLoad, delay));
    }
	
	private IEnumerator LoadWithDelayCoroutine(string sceneToLoad, float delay)
	{
		yield return new WaitForSeconds(delay);
		
        SceneManager.LoadScene(sceneToLoad);
	}
}