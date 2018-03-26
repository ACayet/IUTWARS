using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Target")
        {
            Destroy(collision.gameObject);
        }
    }

}
