using UnityEngine;
using TMPro;


public class DragHandler : MonoBehaviour
{
    public GameObject dragItem;
    public Canvas dragCanvas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip dragStartSfx;

    public void StartDrag(GameObject selectedObject)
    {
        dragItem = Instantiate(selectedObject, Input.mousePosition, selectedObject.transform.rotation) as GameObject;
        dragItem.transform.SetParent(dragCanvas.transform);
        dragItem.GetComponent<TextMeshProUGUI>().raycastTarget = false;

        audioSource.PlayOneShot(dragStartSfx);
    }

    public void Drag()
    {
        dragItem.transform.position = Input.mousePosition;
        dragItem.transform.localScale = new Vector2(1, 1) * 1.1f;
    }

    public void StopDrag()
    {
        Destroy(dragItem);
    }
}
