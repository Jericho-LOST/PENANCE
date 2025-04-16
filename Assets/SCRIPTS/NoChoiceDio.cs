using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NoChoiceDio : MonoBehaviour
{
   //litterally the same thing as my "Next Dio" script minus the choice disapearing thing. htis is for choices with one option 


    public GameObject TalkPannel;
    public GameObject Pannel;
    public Text dialogueText;
    public string[] dialogueLines;
    public float textSpeed = 0.05f;
   // public GameObject Choicesgobyebye; // i think this is pretty self-explanitory :)
    public GameObject Chosen; // this is for the actiual button so it disapears when i want it to (merging the scripts makes the whole thing dissapear though..)


    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;



public void SHOWOBJECT()     // puting it in caps so it can show up against the list of funtions in the button bit
    {
        if (TalkPannel != null)
        {
            TalkPannel.SetActive(true);
            StartDialogue();
        }
    }

    private void Update()
    {
    //    if (TalkPannel == null)
     //   {
      //      StartDialogue();
        //}

        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // If the player presses Space while text is typing this finishes the line instantly
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                // Show the next line of dialogue
                NextLine();
            }
        }
    }


    public void StartDialogue()
    {
        // this activateas the dialogue box and starts the first line
       // Choicesgobyebye.SetActive(false);
        Pannel.SetActive(true);
        dialogueActive = true;
        //fullSprite.SetActive(true); //don't need this causefull pannel is already active//visable
        currentLineIndex = 0;
        StartCoroutine(TypeLine());
    }



    void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            // End the dialogue when all lines are shown
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        // Type each character one by one
        foreach (char c in dialogueLines[currentLineIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {

        dialogueActive = false;
        Pannel.SetActive(false);
        TalkPannel.SetActive(false); // just realised i created two panels that do the same thing...
        Chosen.SetActive (false);
    }
}
