using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContactDio : MonoBehaviour
{
    //this is the TRIGGER for any diolouge i might need, when a player collides with it they will get a dio option. 
    //i then have to place this trigger around the object i want to interact with- beacuse i still can't figure out how to trigger it while the player collides :,)
    // attactch to object.. hopefully  


    public Text dialogueText;
    public GameObject dialogueBox;

    public string[] dialogueLines;
    //public GameObject pressT;//the "press T to Talk" notif that shows up for the player
    public float textSpeed = 0.05f;
    public GameObject fullSprite; //this helps the box dissapear (i oriiginally used it to switch sprites during diolouge scenes)

    //public AudioSource TalkSound;

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
       // pressT.SetActive(false);
    }





    private void OnTriggerEnter2D(Collider2D collision) // found out I had to use 2d.. fml i was using collison variables bacause i pulled this from my 3d script 
    {


        if (collision.gameObject.CompareTag("Player"))// && Input.GetKeyDown(KeyCode.T)) //!! code won't repond to input // needs to heva an "on trigger enter" (and exit) rather than collider

        {
            Debug.Log("test");
            StartDialogue();
           // pressT.SetActive(false);
        
        }

    }
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // If the player presses spacebar while text is typing this finishes the line instantly
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
        dialogueBox.SetActive(true);
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
        //TalkSound.Play();
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
        dialogueBox.SetActive(false);
        dialogueActive = false;
        fullSprite.SetActive(false);
        //pressT.SetValue(false);

    }
}

