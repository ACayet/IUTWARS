using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    DataController dataC;
    GameData loadData;
    public string Scene_to_load;

    private void Start()
    {
        dataC = new DataController();
    }

    public void PlayNewGame()
    {
        dataC.SaveGameData(Scene_to_load);
        SceneManager.LoadScene(Scene_to_load);
    }

    public void ContinuGame()
    {
        loadData = dataC.LoadGameData();
        loadData.PreviousScene = "MainMenu";
        SceneManager.LoadScene("Couloir_Carte");
        SceneManager.LoadScene(loadData.CurentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
