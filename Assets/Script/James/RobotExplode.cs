using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotExplode : MonoBehaviour
{
    public AudioSource boom;
    public void Update()
    {
        if (!boom.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}