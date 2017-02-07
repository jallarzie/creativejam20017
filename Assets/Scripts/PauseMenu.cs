using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private GameObject canvasPause;
	[SerializeField]
	private GameObject cursor;
	[SerializeField]
	private Transform cursorPointResume;
	[SerializeField]
	private Transform cursorPointQuit;

	private AudioSource menuMovement;
	private bool isPaused;
	private bool isResume;

	// Use this for initialization
	void Start () {
		isPaused = false;
		isResume = true;
		menuMovement = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl(InputControlType.Start).WasPressed)
			{
				if (!isPaused) {
					Time.timeScale = 0;
					canvasPause.SetActive (true);
					canvasPause.gameObject.SetActive (true);
					isPaused = true;
				} else if (isPaused) {
					Time.timeScale = 1;
					canvasPause.SetActive (false);
					canvasPause.gameObject.SetActive (false);
					isPaused = false;
				}
			}
			if (canvasPause.activeSelf) {
				if (InputManager.ActiveDevice.DPadRight.WasPressed) {
					cursor.transform.position = cursorPointQuit.position;
					menuMovement.Play();
					isResume = false;
				} else if (InputManager.ActiveDevice.DPadLeft.WasPressed){
					cursor.transform.position = cursorPointResume.position;
					menuMovement.Play();
					isResume = true;
				}
				if (isResume && InputManager.ActiveDevice.Action1.WasPressed) {
					Time.timeScale = 1;
					canvasPause.SetActive (false);
					canvasPause.gameObject.SetActive (false);
					isPaused = false;
				} else if (!isResume && InputManager.ActiveDevice.Action1.WasPressed) {
					Application.Quit ();
				}
			}
		}
	}
}
