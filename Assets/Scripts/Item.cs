using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemException : System.Exception
{
   public ItemException(string message) : base(message)
    {

    }
}

public class Item : ScriptableObject
{
    public Sprite icon;
    public string description;
    public bool isConsumable = false;
    private int id = 0;
    public int Id
    {
        get { return id; }
        set
        {
            id = value;
            throw new ItemException("you cant do that");
        }
    }
    

   public void Use()
    {
        Debug.Log("USed item:" + name + " - " + description);
    }
}
