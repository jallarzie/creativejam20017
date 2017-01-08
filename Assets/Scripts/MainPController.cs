using UnityEngine;
using System.Collections;
using InControl;

public class MainPController : MonoBehaviour {

	private Animator animator;
	private InputDevice inputDevice;
	private ClothesPin currentClothesPin;
	private ClothesPin nextClothesPin;
	private int lineIndex;

	[SerializeField]
	private LineController[] listOfLines;

	[SerializeField]
	private GameObject[] lineEdges;

	[SerializeField]
	private int playerNum;

	// Use this for initialization
	void Start () {
		lineIndex = 1;
		this.transform.position = lineEdges [lineIndex].transform.position;
		animator = GetComponent<Animator> ();
		inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
        currentClothesPin.clothesColor = (ClothesPinColor)(Random.Range (0, 4));
        nextClothesPin.clothesColor = (ClothesPinColor)(Random.Range (0, 4));
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale > 0 && inputDevice != null) {
			if (inputDevice.DPadUp.WasPressed || inputDevice.LeftStickY > 0) {
				if (lineIndex != 0) {
					lineIndex--;
					this.transform.position = lineEdges [lineIndex].transform.position;
				}
			} else if (inputDevice.DPadDown.WasPressed || inputDevice.LeftStickY < 0) {
				if (lineIndex != 2) {
					lineIndex++;
					this.transform.position = lineEdges [lineIndex].transform.position;
				}	
			}
		}
	}
	//A puts pin
	//B changes the pin
}
