using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueAlt : MonoBehaviour
{
    public TextMeshProUGUI textComponment;
    public string[] lines;
    public float textSpeed;
    public int index;
    public Animator UIPop;
    public GameObject UiCanvas;

    // Start is called before the first frame update
    public void Display(int Index)
    {
        index = Index;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponment.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(3);
        textComponment.text = string.Empty;
        gameObject.SetActive(false);
    }
}

