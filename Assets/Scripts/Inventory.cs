using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveable
{

    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    ItemTable itemTable;
    // Start is called before the first frame update
    void Start()
    {
        itemTable.SetItemIDs();

        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>());
        SaveGame.OnSaveEvent += OnSave;
        SaveGame.OnLoadEvent += OnLoad;
    }

    void OnDestroy()
    {
        SaveGame.OnSaveEvent -= OnSave;
        SaveGame.OnLoadEvent -= OnLoad;
    }



    public void OnSave()
    {
        Debug.Log("Inventory Saved");
    }

    public void OnLoad()
    {
        Debug.Log("Inventory Loaded");
    }
}
