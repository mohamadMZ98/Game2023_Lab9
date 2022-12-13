using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

   //private static Traveller Player = null;
    public static Traveller Player
    {
        get;
        private set;
    
    
    }


    // Start is called before the first frame update
    void Start()
    {
        if(Player == null && playerPrefab != null)
        {
           GameObject newPlayer =  Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Player = newPlayer.GetComponent<Traveller>();
        }    
    }

   
}
