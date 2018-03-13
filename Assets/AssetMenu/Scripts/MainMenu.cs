using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    DataController data = new DataController();

    public void PlayNewGame()
    {
        data.SaveGameData();
        SceneManager.LoadScene(1);
    }

    public void ContinuGame()
    {
        DataController data = new DataController();
        data.LoadGameData();
        SceneManager.LoadScene(2);//à adapter
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
