using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHideThing : MonoBehaviour
{
    //NEEDS TWEAKING
    //this is for a button to make something show up- i son't think this works for normal objects...


    public GameObject objectToHide;
    //public TEXT newtext; wondering if i can get the tect to change when the button is clicked... you know? SHOW --> HIDE
    public void SHOWOBJECT()     // puting it in caps so it can show up against the list of funtions in the button bit
        {
            if (objectToHide != null)
            {
                objectToHide.SetActive(true);
               // newtext.SetActive(true);
        }
        }
    
}
