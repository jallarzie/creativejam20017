﻿using UnityEngine;
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
        menuMovement.ignoreListenerPause = true;

    }
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl(InputControlType.Start).WasPressed || InputManager.ActiveDevice.GetControl(InputControlType.Select).WasPressed)
			{
				if (!isPaused) {
					Time.timeScale = 0;
					canvasPause.SetActive (true);
					canvasPause.gameObject.SetActive (true);
                    AudioListener.pause = true;
					isPaused = true;
				} else if (isPaused) {
					Time.timeScale = 1;
					canvasPause.SetActive (false);
					canvasPause.gameObject.SetActive (false);
                    AudioListener.pause = false;
                    isPaused = false;
				}

            }
			if (canvasPause.activeSelf) {
				if (InputManager.ActiveDevice.DPadRight.WasPressed) {
					if (cursor.transform.position != cursorPointQuit.position){
						menuMovement.Play();
					}
					cursor.transform.position = cursorPointQuit.position;
					isResume = false;
				} else if (InputManager.ActiveDevice.DPadLeft.WasPressed){
					if (cursor.transform.position != cursorPointResume.position){
						menuMovement.Play();
					}
					cursor.transform.position = cursorPointResume.position;
					isResume = true;
				}
				if (isResume && InputManager.ActiveDevice.Action1.WasPressed) {
					Time.timeScale = 1;
					canvasPause.SetActive (false);
					canvasPause.gameObject.SetActive (false);
					isPaused = false;
                    AudioListener.pause = false;
                } else if (!isResume && InputManager.ActiveDevice.Action1.WasPressed) {
					Application.Quit ();
				}
			}
		}
	}
}
