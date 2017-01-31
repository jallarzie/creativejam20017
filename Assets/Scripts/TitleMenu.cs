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
	[SerializeField]
	private GameObject selection;
	[SerializeField]
	private GameObject[] P1Selection;
	[SerializeField]
	private GameObject[] P2Selection;
	[SerializeField]
	private GameObject[] P3Selection;
	[SerializeField]
	private GameObject[] P4Selection;
	[SerializeField]
	private GameObject[] cursors;

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}

	public void showInstructions(){
		canvasAnimator.Stop ();
		pressToPlay.SetActive (false);
		title.SetActive (false);
		instructions.SetActive (true);
	}

	public void selectionScreen(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl (InputControlType.Start)) {
				Application.Quit ();
			}
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				if (instructions.activeSelf) {
					instructions.SetActive (false);
					instructions.gameObject.SetActive (false);
					selection.SetActive (true);
					selection.gameObject.SetActive (true);
				} else if (selection.activeSelf) {
					selectionScreen ();
				} else {
					showInstructions ();			
				}
			}
		}
	}
}
