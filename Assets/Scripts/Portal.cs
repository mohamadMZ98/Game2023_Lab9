using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string destinationSpawn = "";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Find out if there is a traveller
        Debug.Log("Portal Entered");
        Traveller traveller = collision.GetComponent<Traveller>();
        if (traveller != null)
        {
            traveller.LastSpawnName = destinationSpawn;  
            SceneManager.LoadScene(gameObject.tag, LoadSceneMode.Single);
            traveller.onTransportToNewScene.Invoke(SceneManager.GetSceneByName(tag));
        }
    }

}
