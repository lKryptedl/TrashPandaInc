using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suck : MonoBehaviour
{
    public AudioSource audioSource;
   
    public void onSuck()
    {
        audioSource.Play();
    }
}
