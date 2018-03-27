using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager {

    private static string gameDataProjectFilePath = "/StreamingAssets/";
    private static string gameDataFileName = "data.save";


    public static void Save(object entity, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(Application.dataPath + gameDataProjectFilePath + "/" + gameDataFileName);
        formatter.Serialize(stream, entity);
        stream.Close();
    }

    public static object Load(string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(Application.dataPath + gameDataProjectFilePath + "/" + gameDataFileName, FileMode.Open);
        var entity = formatter.Deserialize(stream);
        stream.Close();
        return entity;
    }
}
