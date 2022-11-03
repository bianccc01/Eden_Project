using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void SceneSwitcher(string scene)
	{
		SceneManager.LoadScene(scene);
	
	}
}
