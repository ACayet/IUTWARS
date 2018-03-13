using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSon : MonoBehaviour {

    private static GestionSon instance = null;
    public static GestionSon Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } 
        else {  
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
