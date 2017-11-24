using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerEnter(PointerEventData eventData)
    {
        Outline o = GetComponent<Outline>();
        o.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Outline o = GetComponent<Outline>();
        o.enabled = false;
    }
}
