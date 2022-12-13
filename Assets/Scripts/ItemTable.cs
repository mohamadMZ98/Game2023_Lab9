using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/ new item")]
public class ItemTable : ScriptableObject
{
    [SerializeField]
    private List<Item> items;
   
   public void SetItemIDs()
    {
        for (int i = 0; i < items.Count; i++)
        {
            try
            {
                items[i].Id = i;
            }catch(ItemException ex)
            {

            }
            
        }
    }
    public Item GetItemByIndex(int id)
    {
        return items[id];
    }
}
