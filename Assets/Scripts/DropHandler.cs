using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropHandler : MonoBehaviour, IDropHandler
{
    ILetterDropListener letterDropListener;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        string letter = droppedItem.GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = letter;
        //Debug.Log(letter);
        letterDropListener.OnLetterDrop();
    }

    public void AddLetterDropListener(ILetterDropListener listener)
    {
        letterDropListener = listener;
    }

    public interface ILetterDropListener
    {
        void OnLetterDrop();
    }
}
