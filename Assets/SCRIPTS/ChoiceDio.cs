using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChoiceDio : MonoBehaviour
{
    //this version ony apears if a button is pressed  FAILED ATTEMPT 
            // i just need to make the text reapear too-

    public Text dialogueText;
  

    public string[] dialogueLines;

    public float textSpeed = 0.05f;
    public GameObject fullSprite; //this helps the box dissapear (i oriiginally used it to switch sprites during diolouge scenes)

    public GameObject Choices;
    public GameObject OtherChoicegobyebye; // i think this is pretty self-explanitory :)
    public GameObject Pannel;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;
  //  private bool isChosen = false; // this should hopefully make the diolouge work when the option is hhosen 

    private void Start()
    {
        Pannel.SetActive(false);
  
        Choices.SetActive(false);

    }
    void Update()
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
        // pressT.SetValue(true);
        Pannel.SetActive(true);
        dialogueActive = true;
        fullSprite.SetActive(true);
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
        Pannel.SetActive(true);
        dialogueActive = false;
        fullSprite.SetActive(false);

        //Choices.SetActive(true); this will be saved for a second set of choices 


    }
}

