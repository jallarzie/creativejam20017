using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InControl;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    [SerializeField]
    private MainPController mainPlayer;

    [SerializeField]
    private SecondaryPController[] players;

    [SerializeField]
    private LineController[] lines;

    void Start()
    {
        List<string> assignedNames = new List<string>();
        for (int i = 0; i < InputManager.Devices.Count; i++)
        {
            if (i == 0)
            {
                mainPlayer.inputDevice = InputManager.Devices[i];
            }
            else if (i - 1 < players.Length)
            {
                players[i - 1].inputDevice = InputManager.Devices[i];
            }
        }
    }

	void Update ()
    {
        int livingBirds = 0;
        bool gameOver = false;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].isAlive)
            {
                livingBirds++;
            }
        }

        int spinningLines = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].spinning)
            {
                spinningLines++;
            }
        }

        gameOver = livingBirds == 0 || spinningLines == 0;

        if (gameOver)
        {
            PlayerPrefs.SetInt("livingBirds", livingBirds);
            PlayerPrefs.Save();
            SceneManager.LoadScene("scene_ending", LoadSceneMode.Single);
        }
	}
}
