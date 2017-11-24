using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlashingText : MonoBehaviour {

    public Text flashingText;

    void Start()
    {
        //get the Text component
        flashingText = GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    //function to blink the text
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            // fade to transparent over 500ms.
            flashingText.CrossFadeAlpha(0.0f, 0.05f, false);
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
     
            // and back over 500ms.
            flashingText.CrossFadeAlpha(1.0f, 0.05f, false);
            yield return new WaitForSeconds(.5f);
        }
    }
}
