using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour {

    public static bool GameIsPaused;
    public GameObject MenuPauseUI;

    void Start()
    {
        GameIsPaused = false;
    }
        // Update is called once per frame
    void Update () {

        if (!GameIsPaused) // si le jeu 
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale =1;
    }
    void Pause()
    {
        //Debug.Log("Appel de Pause()");
        MenuPauseUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
    public void Quitter()
    {
        Debug.Log("ca quitte");
        Application.Quit();
    }

    public void Continuer()
    {
        TooglePause();
        Resume();
    }

    public void Sauvegarder()
    {
        DataController d = new DataController();
        d.SaveGameData(SceneManager.GetActiveScene().name);
    }
}
