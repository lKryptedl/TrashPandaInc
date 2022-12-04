using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] public GameObject Canvas;
    public static bool DialogueShowing = false;

    //public Animator UIPop;
    //public GameObject UiCanvas;
    
    void Start()
    {
        //UIPop = UiCanvas.GetComponent<Animator>();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hello!");
            Canvas.SetActive(true);
            print("Showing");
            DialogueShowing = true;
            //UIPop.SetBool("DialogueOpen",true);

            //Destroy(gameObject, 5);
        }
    }
    
}
