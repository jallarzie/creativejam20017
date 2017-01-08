using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InControl;

public class CreditsMenu : MonoBehaviour {

	[SerializeField]
	public GameObject canvasToDeactivate;
	[SerializeField]
	public GameObject canvasToActivate;

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 8f || InputManager.ActiveDevice.AnyButton.WasPressed) {
			canvasToDeactivate.SetActive (false);
			canvasToDeactivate.gameObject.SetActive (false);
			canvasToActivate.SetActive (true);
			canvasToActivate.gameObject.SetActive (true);
		}
		if (canvasToActivate.activeSelf && InputManager.ActiveDevice.AnyButton.WasPressed) {
			LoadScene ("scene_title");
		}
	}
}
