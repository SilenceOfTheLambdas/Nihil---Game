using UnityEngine;
using UnityEngine.EventSystems;

public class CloseInventory : MonoBehaviour, IPointerDownHandler
{

    Inventory inv;
    void Start()
    {
        inv = transform.parent.GetComponent<Inventory>();

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inv.closeInventory();
        }
    }
}
