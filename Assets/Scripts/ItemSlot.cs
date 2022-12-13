using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Item item = null;
    private int count = 0;
    public int Count
    {
        get { return Count; } 
        set
        {
            Count = value;
            //UpdateGraphic();
        }
    }

    [SerializeField]
    Image itemIcon;


    [SerializeField]
    TextMeshProUGUI itemCountText;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateGraphic();
    }
    //change icon and count
    //void UpdateGraphic()
    //{
    //    if (count < 1)
    //    {
    //        item = null;
    //        itemIcon.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        itemIcon.sprite = item.icon;
    //        itemIcon.gameObject.SetActive(true);
    //        itemCountText.text = count.ToString();
    //        //set sprite to the one from the item

    //    }
    //}


   public void UseItemSlot()
    {
        if(CanUseItem(item))
        {
            item.Use();
            if(item.isConsumable)
            {
                Count--;
            }
        }
    }

    private bool CanUseItem(Item item)
    {
        if(item == null)
        {
            return false;

            if(count < 1)
            {
                return false;
            }
        }

        return true;
    }
}
