using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] public GameObject Canvas;
    public bool isShowing = false;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hello!");
            Canvas.SetActive(true);
            isShowing = true;

            //Destroy(gameObject, 5);
        }
    }
    
}
