using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private GameObject canvasPause;

	private bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl(InputControlType.Start))
			{
				if (!isPaused) {
					Time.timeScale = 0;
					canvasPause.SetActive (true);
					canvasPause.GetComponent<GameObject> ().SetActive (true);
					isPaused = true;
				} else if (isPaused) {
					Time.timeScale = 1;
					canvasPause.SetActive (false);
					canvasPause.GetComponent<GameObject> ().SetActive (false);
					isPaused = false;
				}
			}
			if (canvasPause.activeSelf) {
				if (InputManager.ActiveDevice.DPadLeft.WasPressed) {
					//cursor should be on quit
				} else if (InputManager.ActiveDevice.DPadRight.WasPressed){
					//cursor should be on resume
				}
			
			}
		}
	}
}
