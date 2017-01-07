using UnityEngine;
using System.Collections;
using InControl;

public class SecondaryPController : MonoBehaviour {

	private Animator animator;
    private InputDevice inputDevice;
	private TriggerCreeper successTrigger;

	[SerializeField]
	private int playerNum;
	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
        successTrigger = GetComponent<TriggerCreeper>();
		inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.localPosition += new Vector3 (speed*Time.deltaTime, 0f, 0f);

		if (inputDevice != null) {
            if (inputDevice.Action1.WasPressed) {
				animator.SetTrigger ("jumping");
                successTrigger.Trigger();
            } else if (inputDevice.Action2.WasPressed) {
                animator.SetTrigger ("jumping");
                successTrigger.Trigger();
            } else if (inputDevice.Action3.WasPressed) {
                animator.SetTrigger ("jumping");
                successTrigger.Trigger();
            } else if (inputDevice.Action4.WasPressed) {
                animator.SetTrigger ("jumping");
                successTrigger.Trigger();
			}
		
			//Crosscheck with pin color
			//Line Controller has the pin list
			//Crosscheck color with LineController (each player will have assignated lines)

		}
	}
}
