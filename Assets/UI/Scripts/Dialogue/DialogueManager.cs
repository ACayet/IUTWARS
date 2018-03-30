using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

    public Text TextDialogue;
    public Text TextNom;
    public Queue<string> phrases;

    public Animator animator;

	// Use this for initialization
	void Start () {
        phrases = new Queue<string>();
	}
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        TextNom.text = dialogue.nom;
        Debug.Log("Starting conversation with " + dialogue.nom);
        phrases.Clear();
        foreach (string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(phrases.Count == 0)
        {
            EndDialogue();
            return;
        }
        string phrase = phrases.Dequeue();
        TextDialogue.text = phrase;
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("Fin de la conversation.");
    }
}
