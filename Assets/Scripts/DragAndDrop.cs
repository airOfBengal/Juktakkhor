using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DragAndDrop : MonoBehaviour
{
    public GameObject dragItem;
    public Canvas dragCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDrag(GameObject selectedObject)
    {
        dragItem = Instantiate(selectedObject, Input.mousePosition, selectedObject.transform.rotation) as GameObject;
        dragItem.transform.SetParent(dragCanvas.transform);
        dragItem.transform.localScale = 1.1f * dragItem.transform.localScale;
        dragItem.GetComponent<TextMeshProUGUI>().raycastTarget = false;
    }

    public void Drag()
    {
        dragItem.transform.position = Input.mousePosition;
    }

    public void StopDrag()
    {
        Destroy(dragItem);
    }

    public void Drop(TextMeshProUGUI dropSlot)
    {
        GameObject droppedItem = dragCanvas.transform.GetChild(0).gameObject;
        dropSlot.text = droppedItem.GetComponent<TextMeshProUGUI>().text;
    }
}
