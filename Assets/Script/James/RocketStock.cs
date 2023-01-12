using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStock : MonoBehaviour
{
    private int maxBullets = 4;
    public bool collecting = false;
    public float delay = 0;
    public int giveOut = 3;
   /* void Update()
    {
        if (collecting == true && delay <= 0)
        {
            Shooting.rocketCount++;
            delay = giveOut;
        }
        else if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Shooting.rocketCount < maxBullets)
            {
                Shooting.rocketCount = maxBullets;
            }
            //collecting = true;

        }
    }
    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //collecting = false;
        }
    }*/
}
