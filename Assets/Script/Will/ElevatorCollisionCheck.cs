using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCollisionCheck : MonoBehaviour
{
    public Transform player;
    public Transform Platform;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = Platform.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
