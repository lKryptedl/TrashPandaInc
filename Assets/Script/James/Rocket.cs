using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rubbish;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BigRubbish")) //Destroys big rubbish
        {
            Destroy(other.gameObject);
            for (int x = 0; x < 4; x++)
            {
                Instantiate(rubbish, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Robot")) //Destroys robot
        {
            Destroy(other.gameObject);
            Score.PlayerScore += 500;
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) //Collision destroying rocket
        {
            Destroy(gameObject);
        }
    }
}
