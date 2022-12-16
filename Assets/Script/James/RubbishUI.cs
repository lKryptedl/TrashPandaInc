using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubbishUI : MonoBehaviour
{
    public Sprite[] spriteArray;
    public Image rubbishImage;
    public void Update()
    {
        if (Shooting.RubbishStored == 0)
        {
            rubbishImage.sprite = spriteArray[0];
        }
        else if (Shooting.RubbishStored > 11)
        {
            rubbishImage.sprite = spriteArray[6];
        }
        else if (Shooting.RubbishStored > 9)
        {
            rubbishImage.sprite = spriteArray[5];
        }
        else if (Shooting.RubbishStored > 7)
        {
            rubbishImage.sprite = spriteArray[4];
        }
        else if (Shooting.RubbishStored > 5)
        {
            rubbishImage.sprite = spriteArray[3];
        }
        else if (Shooting.RubbishStored > 3)
        {
            rubbishImage.sprite = spriteArray[2];
        }
        else if (Shooting.RubbishStored > 0)
        {
            rubbishImage.sprite = spriteArray[1];
        }
    }
}
