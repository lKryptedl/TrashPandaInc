using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponment;
    public string[] lines;
    public float textSpeed;

    //public Animator UIPop;
    public GameObject UiCanvas;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponment.text = string.Empty;
        StartDialogue();
        //UIPop = UiCanvas.GetComponent<Animator>();
        //UIPop.SetBool("DialogueOpen",true);

    }

    // Update is called once per frame
    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if(gamepad.aButton.wasPressedThisFrame) //change abutton to whatever button you want to skip.
        {
            if (textComponment.text == lines[index])
            {
                NextLine();
            }
            else
            {
                
                StopAllCoroutines();
                textComponment.text = lines[index];
                
            }
        }
    }

    void StartDialogue()
    {
        
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponment.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponment.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            DialogueTrigger.DialogueShowing = false;

        }
    }
}
    
