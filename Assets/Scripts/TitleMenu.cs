using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class TitleMenu : MonoBehaviour {

	[SerializeField]
	private Animator canvasAnimator;
	[SerializeField]
	private GameObject pressToPlay;
	[SerializeField]
	private GameObject instructions;
	[SerializeField]
	private GameObject title;
	[SerializeField]
	private GameObject selectionScreen;
	[SerializeField]
	private GameObject[] p1Selection;
	[SerializeField]
	private GameObject[] p2Selection;
	[SerializeField]
	private GameObject[] p3Selection;
	[SerializeField]
	private GameObject[] p4Selection;
	[SerializeField]
	private GameObject[] cursors;

    private int[] cursorPositions;

	private List<GameObject[]> pSelection;

	public void Start(){
        pSelection = new List<GameObject[]>();
		pSelection.Add(p1Selection);
        pSelection.Add(p2Selection);
        pSelection.Add(p3Selection);
        pSelection.Add(p4Selection);
        cursorPositions = new int[] { 0, 0, 0, 0 };
    }

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}

	public void showInstructions(){
		canvasAnimator.Stop ();
		pressToPlay.SetActive (false);
		title.SetActive (false);
		instructions.SetActive (true);
	}

    void Update() {

        for (int i = 0; i < InputManager.Devices.Count; i++)
        {
            InputDevice device = InputManager.Devices[i];
            if (!selectionScreen.activeSelf)
            {
                if (device.AnyButton.WasPressed)
                {
                    if (instructions.activeSelf)
                    {
                        instructions.SetActive(false);
                        instructions.gameObject.SetActive(false);
                        selectionScreen.SetActive(true);
                        selectionScreen.gameObject.SetActive(true);
                    }
                    else
                    {
                        showInstructions();
                    }
                }
            }
            else
            {
                if (InputMapper.Instance.IsDeviceMapped(device))
                {
                    int playerID = InputMapper.Instance.GetDevicePlayer(device);

                    int cursorPosition = cursorPositions[playerID];

                    if (device.AnyButton.WasPressed)
                    {
                        if (device.Action1.WasPressed)
                        {
                            InputMapper.Instance.SetPlayerCharacter(playerID, cursorPosition);
                        }
                        else if (device.Action2.WasPressed)
                        {
                            InputMapper.Instance.ClearPlayerCharacter(playerID);
                            InputMapper.Instance.MapDevice(playerID, null);
                            cursors[playerID].SetActive(false);
                        }
                    }
                    else if (InputMapper.Instance.GetPlayerCharacter(playerID) == -1)
                    {
                        if (device.DPadRight.WasPressed)
                        {
                            if (cursorPosition < 3)
                            {
                                cursorPosition++;
                            }
                        }
                        else if (device.DPadLeft.WasPressed)
                        {
                            if (cursorPosition > 0)
                            {
                                cursorPosition--;
                            }
                        }
                        else if (device.DPadDown.WasPressed)
                        {
                            if (cursorPosition == 0)
                            {
                                cursorPosition = 2;
                            }
                        }
                        else if (device.DPadUp.WasPressed)
                        {
                            if (cursorPosition != 0)
                            {
                                cursorPosition = 0;
                            }
                        }

                        cursors[playerID].transform.position = pSelection[playerID][cursorPosition].transform.position;
                        cursorPositions[playerID] = cursorPosition;
                    }
                }
                else
                {
                    if (device.AnyButton.WasPressed)
                    {
                        int playerID = InputMapper.Instance.GetFirstAvailablePlayer();

                        if (playerID > -1)
                        {
                            InputMapper.Instance.MapDevice(playerID, device);
                            cursors[playerID].SetActive(true);
                        }
                    }
                }
            }
        }
	}
}
