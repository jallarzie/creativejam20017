using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class StoryMenu : MonoBehaviour {
	
	[SerializeField]
	private Animator canvasAnimator;

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
    }

    public void Update()
    {
		if (Time.timeSinceLevelLoad > 12f) {
			LoadScene ("scene_title");
		} else if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				LoadScene ("scene_title");
			}
		}
    }
}
