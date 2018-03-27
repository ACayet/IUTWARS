using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files
using UnityEditor;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    GameData data = new GameData();
    public Text LoadData = GameObject.Find("DataLoad").GetComponent<Text>();

    private static string gameDataFileName = "data.save";
    private string gameDataProjectFilePath = "/StreamingAssets/" + gameDataFileName;

    void Start()
    {
        //SaveGameData();

        //LoadGameData();

        LoadData.text = "Commence par créer une nouvelle partie ";
    }

    public void LoadGameData()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;
        //try
        //{
            GameData dataL = (GameData)DataManager.Load(filePath);
            Debug.Log("Data load !");
            //Debug.Log(dataL.AttackPlayer.ToString());

            LoadData.text = dataL.AttackPlayer.ToString();


        //}
        //catch (System.Exception)
        //{
        //    throw new IOException("Load fail !");
        //}
    }

    public void SaveGameData()
    {
        Debug.Log("Data save in "+ Application.dataPath + gameDataProjectFilePath);
        GameData data = new GameData();
        data.AttackPlayer = 5;
        data.HPPlayer = 5;
        data.PAPlayer = 5;
        data.PMPlayer = 5;
        data.DefensePlayer = 5;
        data.portéePlayer = 2;

        DataManager.Save(data, gameDataFileName);

    }

} 