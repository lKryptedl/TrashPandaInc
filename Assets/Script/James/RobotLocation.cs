using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLocation : MonoBehaviour
{
    public static int PlaceLocation;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Bridge Detect")
        {
            PlaceLocation = 1;
        }
        else if (other.GetComponent<Collider>().name == "Lounge Detect")
        {
            PlaceLocation = 2;
        }
    }
}
