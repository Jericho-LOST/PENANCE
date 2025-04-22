using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OnHover : MonoBehaviour
{
    //FAILED SCRIPT!! might try again later (probably wont) 
    //this script attempts to spawn text when the mouse hovers over an object
    // note that object must have a box collider!!



    public GameObject TalkPannel;// i dont actually think i need this// edit: i do in fact need it: (remind me to switch name to "full sprite or smtn")
    public GameObject Pannel;
    public Text dialogueText;
    public string[] dialogueLines;
    public float textSpeed = 0.05f; 
    public GameObject ChosenOption; // this is for the actiual button so it disapears when i want it to (merging the scripts makes the whole thing dissapear though..)


    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;
    private void OnMouseEnter() // i think adding the typical funtions to this will be fine? 
    {
            StartDialogue();

    }

    private void OnMouseExit()
    {
        // i don't exactly want to "end diolouge" when the mouse moves...
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

    private void Update()
    {
      

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
        ChosenOption.SetActive(false);
    }


}
