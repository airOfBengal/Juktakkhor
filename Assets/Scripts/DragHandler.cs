using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DragHandler : MonoBehaviour
{
    public GameObject dragItem;
    public Canvas dragCanvas;

    public void StartDrag(GameObject selectedObject)
    {
        dragItem = Instantiate(selectedObject, Input.mousePosition, selectedObject.transform.rotation) as GameObject;
        dragItem.transform.SetParent(dragCanvas.transform);
        dragItem.GetComponent<TextMeshProUGUI>().raycastTarget = false;
    }

    public void Drag()
    {
        dragItem.transform.position = Input.mousePosition;
        dragItem.transform.localScale = new Vector2(1, 1);
    }

    public void StopDrag()
    {
        Destroy(dragItem);
    }
}
