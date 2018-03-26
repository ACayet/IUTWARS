using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files
using UnityEditor;

public class DataController : MonoBehaviour
{
    GameData data = new GameData();

    private string gameDataFileName = "data.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        
    }

    private string gameDataProjectFilePath = "/StreamingAssets/data.json";

    [MenuItem("Window/Game Data Editor")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(DataController)).Show();
    }

    void OnGUI()
    {
        if (data != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("data");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            }
        }

        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }
    }

    /*   public void SubmitNewPlayerScore(int newScore)
       {
           // If newScore is greater than playerProgress.highestScore, update playerProgress with the new value and call SavePlayerProgress()
           if (newScore > playerProgress.highestScore)
           {
               playerProgress.highestScore = newScore;
               SavePlayerProgress();
           }
       }
   */

    public void LoadGameData()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;
        try
        {
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                data = JsonUtility.FromJson<GameData>(dataAsJson);
            }
        }
        catch (System.Exception)
        {

            throw new IOException();
        }
    }

    public void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(data);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
        Debug.Log("Data save !!!");

    }

    /*  // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
      private void LoadPlayerProgress()
      {
          // Create a new PlayerProgress object
          playerProgress = new PlayerProgress();

          // If PlayerPrefs contains a key called "highestScore", set the value of playerProgress.highestScore using the value associated with that key
          if (PlayerPrefs.HasKey("highestScore"))
          {
              playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
          }
      }
      */

} 