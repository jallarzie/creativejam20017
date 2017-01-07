using UnityEngine;
using System.Collections;
using InControl;

public class MainPController : MonoBehaviour {

	private Animator animator;
	private InputDevice inputDevice;

	[SerializeField]
	private int playerNum;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
