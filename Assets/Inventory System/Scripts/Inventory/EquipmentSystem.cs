using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class EquipmentSystem : MonoBehaviour
{
    [SerializeField]
    public int slotsInTotal;
    [SerializeField]
    public ItemType[] itemTypeOfSlots = new ItemType[999];

    public void getSlotsInTotal()
    {
        Inventory inv = GetComponent<Inventory>();
        slotsInTotal = inv.width * inv.height;
    }
#if UNITY_EDITOR
    [MenuItem("Master System/Create/Equipment")]        //creating the menu item
    public static void menuItemCreateInventory()       //create the inventory at start
    {
        GameObject Canvas = null;
        if (GameObject.FindGameObjectWithTag("Canvas") == null)
        {
            GameObject inventory = new GameObject();
            inventory.name = "Inventories";
            Canvas = Instantiate(Resources.Load("Prefabs/Canvas - Inventory") as GameObject);
            Canvas.transform.SetParent(inventory.transform, true);
            GameObject panel = Instantiate(Resources.Load("Prefabs/Panel - EquipmentSystem") as GameObject);
            panel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            panel.transform.SetParent(Canvas.transform, true);
            GameObject draggingItem = Instantiate(Resources.Load("Prefabs/DraggingItem") as GameObject);
            draggingItem.transform.SetParent(Canvas.transform, true);
            Instantiate(Resources.Load("Prefabs/EventSystem") as GameObject);
            Inventory inv = panel.AddComponent<Inventory>();
            panel.AddComponent<InventoryDesign>();
            panel.AddComponent<EquipmentSystem>();
            inv.getPrefabs();
        }
        else
        {
            GameObject panel = Instantiate(Resources.Load("Prefabs/Panel - EquipmentSystem") as GameObject);
            panel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
            panel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            Inventory inv = panel.AddComponent<Inventory>();
            panel.AddComponent<EquipmentSystem>();
            DestroyImmediate(GameObject.FindGameObjectWithTag("DraggingItem"));
            GameObject draggingItem = Instantiate(Resources.Load("Prefabs/DraggingItem") as GameObject);
            panel.AddComponent<InventoryDesign>();
            draggingItem.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
            inv.getPrefabs();
        }
    }
#endif

}

