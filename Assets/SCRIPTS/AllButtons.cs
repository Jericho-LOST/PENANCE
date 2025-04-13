using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AllButtons : MonoBehaviour

{
    //public AudioSource ButtonSound;

    public void settingsLVL()
    {
       // ButtonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void BackToStart()
    {
        // ButtonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }


    public void NextLevel()
    {
        // ButtonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //just add a new scene//level and make sure it is placed first in the Build Settings!

    // just realised i could add more classes instaed of making a new script every time... 
    //i'm an actual dumbass lmao


    public void NewDiologue() // wondering if i can get the button to spawn a new diolouge 
    {

    }
}

