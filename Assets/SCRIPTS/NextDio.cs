using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDio : MonoBehaviour
{
    // this can be used for any game object if attached to a button 


    public GameObject TalkPannel;

    public void SHOWOBJECT()     // puting it in caps so it can show up against the list of funtions in the button bit
    {
        if (TalkPannel != null)
        {
            TalkPannel.SetActive(true);
        }
    }
}
