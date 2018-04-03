using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files
using UnityEditor;
using UnityEngine.UI;
using System;

public class DataController : MonoBehaviour
{
    GameData data;
    //public Text LoadData;

    private static string gameDataFileName;
    private string gameDataProjectFilePath;

    void Start()
    {
        data = new GameData();

        //SaveGameData();

        //LoadGameData();
        //LoadData = GameObject.Find("DataLoad").GetComponent<Text>();
        gameDataFileName = "data.save";
        gameDataProjectFilePath = "/StreamingAssets/" + gameDataFileName;
        //LoadData.text = "Commence par créer une nouvelle partie ";
    }

    public GameData LoadGameData()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;
        //try
        //{
            GameData dataL = (GameData)DataManager.Load(filePath);
            Debug.Log("Data load !");
            Debug.Log(dataL.AttackPlayer.ToString());

        //  LoadData.text = dataL.AttackPlayer.ToString();
            return dataL;

        //}
        //catch (System.Exception)
        //{
        //    throw new IOException("Load fail !");
        //}

    }

    public void SaveGameData(string SceneNameToLoad)
    {
        Debug.Log("Data save in "+ Application.dataPath + gameDataProjectFilePath);
        GameData data = new GameData();
        data.CurentScene = SceneNameToLoad;

        DataManager.Save(data, gameDataFileName);

    } 

} 