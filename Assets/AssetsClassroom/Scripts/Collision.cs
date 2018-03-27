using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private MouvementPersonnage script;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        MouvementPersonnage script = gameObject.GetComponent<MouvementPersonnage>();
        Vector3 oldPos = script.getPosPlayer();
        oldPos.y = oldPos.y - 1;
        
        gameObject.transform.SetPositionAndRotation(oldPos, gameObject.transform.rotation);
        Debug.Log(gameObject.transform.position.ToString());
        
    }

}
