using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropHandler : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        //GameObject droppedItem = dragCanvas.transform.GetChild(0).gameObject;
        GameObject droppedItem = eventData.pointerDrag;
        string letter = droppedItem.GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = letter;
        Debug.Log(letter);

    }
}
