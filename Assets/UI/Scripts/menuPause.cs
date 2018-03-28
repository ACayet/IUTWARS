using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPause : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject MenuPauseUI;


        // Update is called once per frame
        void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        MenuPauseUI.SetActive(false);
        //Time.timeScale =1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        MenuPauseUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
