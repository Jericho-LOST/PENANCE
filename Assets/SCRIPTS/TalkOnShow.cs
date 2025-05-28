using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TalkOnShow : MonoBehaviour
{
    // this is the script that creates a diolouge whn propled by the last diolouge... i don't know how to explain it. 
    //NO BUTTON NEEDED
    //will go onto the next diolouge// button  

    public GameObject FullSprite;


    public GameObject Pannel;
    public Text dialogueText;
    public string[] dialogueLines;
    public float textSpeed = 0.05f;
    public GameObject NewChoices;


    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;

    void Start()
    {
        if (FullSprite != null) 
        {
            StartDialogue();
        }
    }

    // Update is called once per frame
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
        FullSprite.SetActive(false); // just realised i created two panels that do the same thing...
        NewChoices.SetActive(true);
    }
}
