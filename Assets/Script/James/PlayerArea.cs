using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Bridge Detect")
        {
            RobotPlacement.PlayersLocation = 1;
        }
        else if (other.GetComponent<Collider>().name == "Lounge Detect")
        {
            RobotPlacement.PlayersLocation = 2;
        }
    }
}
