using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    
    public string SceneToLoad;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("loading menu");
            LoadingScript.leveltoload = SceneToLoad;
            SceneManager.LoadScene("Loading");
            Player.GetComponent<PlayerController>().Change();
        }
    }

   

}
