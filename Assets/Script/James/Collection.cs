using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    void OnTriggerEnter(Collider other) //Rubbish hits robot
    {
        if (other.CompareTag("Rubbish"))
        {
            Shooting.Balls.Remove(other.gameObject);
            Destroy(other.gameObject);
            Score.PlayerScore += 100;
        }
    }
}
