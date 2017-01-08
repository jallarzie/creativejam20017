using UnityEngine;
using System.Collections;
using InControl;

public class MainPController : MonoBehaviour {

	private Animator animator;
	private InputDevice inputDevice;
	private ClothesPin currentClothesPin;
	private ClothesPin nextClothesPin;
	private int lineIndex;
	private float minimumX;
	private float maximumX;

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
		minimumX = this.transform.position.x;
		maximumX = listOfLines [1].birdStopPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 temp;

		if (Time.timeScale > 0 && inputDevice != null) {
			if (inputDevice.DPadUp.WasPressed) {
				if (lineIndex != 0) {
					lineIndex--;
					temp = this.transform.position;
					temp.y = lineEdges [lineIndex].transform.position.y;
					transform.position = temp;
				}
			} else if (inputDevice.DPadDown.WasPressed) {
				if (lineIndex != 2) {
					lineIndex++;
					temp = this.transform.position;
					temp.y = lineEdges [lineIndex].transform.position.y;
					transform.position = temp;
				}
			}
//			} else if (inputDevice.DPadLeft.WasPressed && this.transform.position.x >= minimumX) {
//				this.transform.position += new Vector3 (-3f, 0f, 0f);
//			} else if (inputDevice.DPadRight.WasPressed && this.transform.position.x < maximumX) {
//				this.transform.position += new Vector3 (3f, 0f, 0f);
//			}
		}
	}
	//A puts pin
	//B changes the pin
}
