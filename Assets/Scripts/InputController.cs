using UnityEngine;
using System.Collections;
using InControl;

public class InputController : MonoBehaviour {

	public enum ColorPressed {
		Blue,
		Yellow,
		Red,
		Green
	}

	public struct ControllerInput {
		public ColorPressed color;
	}

	private InputDevice player1;
	private InputDevice player2;
	private InputDevice player3;
	private InputDevice player4;

	void Start(){
		//player1 = InputManager.Devices [0];
		//player2 = InputManager.Devices [1];
		//player3 = InputManager.Devices [2];
		//player4 = InputManager.Devices [3];
	}

	// Update is called once per frame
	void Update () {
	
		ControllerInput controllerInput = new ControllerInput ();

		//X button
		if (InputManager.ActiveDevice.Action1.WasPressed) {
			Debug.Log ("Supposedely pressed A");
			controllerInput.color = ColorPressed.Green;
		}
		if (InputManager.ActiveDevice.Action1.WasPressed) {
			Debug.Log ("Supposedely pressed B");
			controllerInput.color = ColorPressed.Red;
		}
		if (InputManager.ActiveDevice.Action1.WasPressed) {
			Debug.Log ("Supposedely pressed X");
			controllerInput.color = ColorPressed.Blue;
		}
		if (InputManager.ActiveDevice.Action1.WasPressed) {
			Debug.Log ("Supposedely pressed Y");
			controllerInput.color = ColorPressed.Yellow;
		}
	}
}
