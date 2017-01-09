using UnityEngine;
using System.Collections;
using InControl;

public class SecondaryPController : MonoBehaviour {

	private Animator animator;
    public InputDevice inputDevice;

	[SerializeField]
	private int playerNum;
	[SerializeField]
	private float speed;
    [SerializeField]
    private LineController line;

    private float balance = 1.0f;

    public bool isAlive
    {
        get { return balance > 0f; }
    }

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            if (this.transform.position.x < line.birdStopPosition)
            {
                this.transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                if (Time.timeScale > 0 && inputDevice != null)
                {
                    if (inputDevice.Action1.WasPressed)
                    {
                        animator.SetTrigger("jumping");
                        if (line.JumpPin(ClothesPinColor.Green))
                        {
                            Jump();
                        }
                    }
                    else if (inputDevice.Action2.WasPressed)
                    {
                        animator.SetTrigger("jumping");
                        if (line.JumpPin(ClothesPinColor.Red))
                        {
                            Jump();
                        }
                    }
                    else if (inputDevice.Action3.WasPressed)
                    {
                        animator.SetTrigger("jumping");
                        if (line.JumpPin(ClothesPinColor.Blue))
                        {
                            Jump();
                        }
                    }
                    else if (inputDevice.Action4.WasPressed)
                    {
                        animator.SetTrigger("jumping");
                        if (line.JumpPin(ClothesPinColor.Yellow))
                        {
                            Jump();
                        }
                    }
                }
            }
        }
        else
        {
            if (transform.localPosition.y > -100f)
            {
                transform.localPosition += new Vector3(0f, 30f * -speed * Time.deltaTime, 0f);
            }
        }
	}

    private void Jump()
    {
        balance = Mathf.Min(1.0f, balance + 0.1f);
        animator.SetFloat("balance", balance);
    }

    public void Stumble()
    {
        balance = Mathf.Max(0.0f, balance - 0.1f);
        animator.SetFloat("balance", balance);
    }
}
