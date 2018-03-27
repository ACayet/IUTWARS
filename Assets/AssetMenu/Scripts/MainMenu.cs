using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    DataController data = new DataController();
    public string Scene_to_load;

    public void PlayNewGame()
    {
        SceneManager.LoadScene(Scene_to_load);
    }

    public void ContinuGame()
    {
        data.LoadGameData();
        SceneManager.LoadScene(2);//à adapter
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
