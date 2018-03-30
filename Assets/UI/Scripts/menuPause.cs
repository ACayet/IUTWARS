using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPause : MonoBehaviour {

    public static bool GameIsPaused = true;
    public GameObject MenuPauseUI;


        // Update is called once per frame
        void Update () {

        if (GameIsPaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TooglePause();
        }
	}

    void TooglePause()
    {
        Debug.Log("inversion de GameIsPaused");
        Debug.Log(GameIsPaused + " --> " + !GameIsPaused);
        GameIsPaused = !GameIsPaused;
    }
    void Resume()
    {
        Debug.Log("Appel de Resume()");
        MenuPauseUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale =1;
    }
    void Pause()
    {
        Debug.Log("Appel de Pause()");
        MenuPauseUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
}
