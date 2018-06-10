using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class ShowTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{         //Tooltip

    public Tooltip tooltip;                                     //The tooltip script
    public GameObject tooltipGameObject;                        //the tooltip as a GameObject
    public RectTransform canvasRectTransform;                    //the panel(Inventory Background) RectTransform
    public RectTransform tooltipRectTransform;                  //the tooltip RectTransform
    private Item item;


    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Tooltip") != null)
        {
            tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
            tooltipGameObject = GameObject.FindGameObjectWithTag("Tooltip");
            tooltipRectTransform = tooltipGameObject.GetComponent<RectTransform>() as RectTransform;
        }
        canvasRectTransform = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>() as RectTransform;
    }

    public void OnPointerEnter(PointerEventData data)                               //if you hit a item in the slot
    {
        if (tooltip != null && MouseButton.LeftMouse)
        {
            item = GetComponent<ItemOnObject>().item;                   //we get the item
            tooltip.item = item;                                        //set the item in the tooltip
            tooltip.activateTooltip();                                  //set all informations of the item in the tooltip
            if (canvasRectTransform == null)
                return;


            Vector3[] slotCorners = new Vector3[4];                     //get the corners of the slot
            GetComponent<RectTransform>().GetWorldCorners(slotCorners); //get the corners of the slot                

            Vector2 localPointerPosition;
        }

    }

    public void OnPointerExit(PointerEventData data)                //if we go out of the slot with the item
    {
        if (tooltip != null)
            tooltip.deactivateTooltip();            //the tooltip getting deactivated
    }

}
