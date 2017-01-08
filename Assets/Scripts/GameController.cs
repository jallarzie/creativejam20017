using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private SecondaryPController[] players;

    [SerializeField]
    private LineController[] lines;

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
