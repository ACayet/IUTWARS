using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSon : MonoBehaviour
{
    public Object objet;
    void Awake()
    {
        DontDestroyOnLoad(objet);
    }
}
