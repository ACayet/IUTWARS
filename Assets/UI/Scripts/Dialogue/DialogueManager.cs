using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public Queue<string> phrases;


	// Use this for initialization
	void Start () {
        phrases = new Queue<string>();
	}
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.nom);
        phrases.Clear();
        foreach (string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }
        
    }
    public void DisplayNextSentence()
    {
        if(phrases.Count == 0)
        {
            EndDialogue();
            return;
        }
        string phrase = phrases.Dequeue();
        Debug.Log(phrase);
    }
    public void EndDialogue()
    {
        Debug.Log("Fin de la conversation.");
    }
}
