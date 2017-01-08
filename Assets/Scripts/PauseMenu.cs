using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private GameObject pauseText;

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
					pauseText.SetActive (true);
					isPaused = true;
				} else if (isPaused) {
					Time.timeScale = 1;
					pauseText.SetActive (false);
					isPaused = false;
				}
			}
		}
	}
}
