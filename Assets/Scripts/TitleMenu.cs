using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class TitleMenu : MonoBehaviour {

	[SerializeField]
	private Animator canvasAnimator;
	[SerializeField]
	private GameObject pressToPlay;
	[SerializeField]
	private GameObject instructions;
	[SerializeField]
	private GameObject title;

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}

	public void showInstructions(){
		canvasAnimator.Stop ();
		pressToPlay.SetActive (false);
		title.SetActive (false);
		instructions.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl (InputControlType.Start)) {
				Application.Quit ();
			}
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				Debug.Log ("button was pressed");
				if (instructions.activeSelf) {
					LoadScene ("scene_main");
				} else {
					showInstructions ();			
				}
			}
		}
	}
}
