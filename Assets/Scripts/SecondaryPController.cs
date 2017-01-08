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
    [SerializeField]
    private LineController line;

    private float balance = 1.0f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
        successTrigger = GetComponent<TriggerCreeper>();
		inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.x < line.birdStopPosition)
        {
            this.transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            if (!line.spinning)
            {
                line.StartSpinning();
            }

            if (inputDevice != null)
            {
                if (inputDevice.Action1.WasPressed)
                {
                    if (line.JumpPin(ClothesPinColor.Green))
                    {
                        Jump();
                    }
                    else
                    {
                        Stumble();
                    }
                }
                else if (inputDevice.Action2.WasPressed)
                {
                    if (line.JumpPin(ClothesPinColor.Red))
                    {
                        Jump();
                    }
                    else
                    {
                        Stumble();
                    }
                }
                else if (inputDevice.Action3.WasPressed)
                {
                    if (line.JumpPin(ClothesPinColor.Blue))
                    {
                        Jump();
                    }
                    else
                    {
                        Stumble();
                    }
                }
                else if (inputDevice.Action4.WasPressed)
                {
                    if (line.JumpPin(ClothesPinColor.Yellow))
                    {
                        Jump();
                    }
                    else
                    {
                        Stumble();
                    }
                }
            }
        }
	}

    private void Jump()
    {
        animator.SetTrigger("jumping");
        successTrigger.Trigger();
        balance = Mathf.Min(1.0f, balance + 0.1f);
        animator.SetFloat("balance", balance);
    }

    public void Stumble()
    {
        balance = Mathf.Max(0.0f, balance - 0.5f);
        animator.SetFloat("balance", balance);
    }
}
