using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class TitleMenu : MonoBehaviour {

	[SerializeField]
	private Animator canvasAnimator;
	[SerializeField]
	private GameObject instructions;

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl (InputControlType.Start)) {
				Application.Quit ();
			}
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				if (!instructions.activeSelf) {
					canvasAnimator.Stop ();
					instructions.SetActive (true);
				} else if (instructions.activeSelf) {
					LoadScene ("scene_main");			
				}
			}
		}
	}
}
