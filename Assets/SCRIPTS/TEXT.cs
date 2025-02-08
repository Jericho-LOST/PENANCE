using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TEXT: MonoBehaviour
{


    public Text dialogueText;
    public string[] dialogueLines;
    public float textSpeed = 0.05f;
    

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;

    private void Start()
    {
        
 
            StartDialogue();
          

    }
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // If the player presses F while text is typing this finishes the line instantly
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
       
        dialogueActive = true;
        currentLineIndex = 2;
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

        //dialogueActive = false;
       
      

    }
}
