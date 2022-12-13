using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveGame : MonoBehaviour
{
    [SerializeField]
    int myIntToSave = 1337;

    [SerializeField]
    string saveKey = "My Int";

    public delegate void OnSaveListener();

    public static event OnSaveListener OnSaveEvent;

    public delegate void OnLoadListener();

    public static event OnLoadListener OnLoadEvent;

   
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

       
    }

    public void Save()
    {
        //OnSaveEvent.Invoke();
        PlayerPrefs.SetInt(saveKey, myIntToSave);
        Debug.Log("Game Saved");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            myIntToSave = PlayerPrefs.GetInt(saveKey);
            Debug.Log("Game Loaded");
        }

        // OnLoadEvent.Invoke();
        //myIntToSave = PlayerPrefs.GetInt(saveKey);

    }
}
