using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinuGame()
    {
        SceneManager.LoadScene(2);//à adapter
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
