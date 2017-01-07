using UnityEngine;
using System.Collections;
using InControl;

public class MainPController : MonoBehaviour {

	private Animator animator;
	private InputDevice inputDevice;
	private ClothesPin currentClothesPin;
	private ClothesPin nextClothesPin;

	[SerializeField]
	private int playerNum;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		currentClothesPin.clothesColor = (ClothesPinColor)(Random.Range (0, 4));
		nextClothesPin.clothesColor = (ClothesPinColor)(Random.Range (0, 4));
	}
	
	// Update is called once per frame
	void Update () {

		if (inputDevice != null) {
			if (inputDevice.DPadUp.WasPressed || inputDevice.LeftStickY > 0) {
				//Line Position
				this.transform.localPosition += new Vector3 (0f, 1f, 0f);
			} else if (inputDevice.DPadDown.WasPressed || inputDevice.LeftStickY < 0) {
				this.transform.localPosition += new Vector3 (0f, -1f, 0f);		
			}
		}
	}
	//A puts pin
	//B changes the pin
}
