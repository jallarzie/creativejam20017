using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InControl;

public class MainMenu : MonoBehaviour {
	
    [SerializeField]
    private GameObject toCancel;
    [SerializeField]
    private GameObject instructions;
	[SerializeField]
	private Animator canvasAnimator;

    public void ShowText1()
    {
		canvasAnimator.Stop();
		toCancel.SetActive(false);
		instructions.SetActive(true);
    }

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
    }

    public void Update()
    {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.RightStickButton.WasPressed)
			{
				Application.Quit();
			}
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				if (instructions.activeSelf) {
					LoadScene ("scene_main");
				} else {
					ShowText1 ();
				}

			}
		}

    }
}
