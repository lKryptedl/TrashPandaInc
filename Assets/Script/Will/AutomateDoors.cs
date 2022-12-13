using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateDoors : MonoBehaviour
{
   
    public float smoothTime;
    public Transform DoorLeft, DoorRight;
    private Vector3 velocity = Vector3.zero;
    public bool Move;
    public Vector3 RightTarget, LeftTarget;
    private Vector3 OriginalPosLeft, OriginalPosRight;
    private void Start()
    {
        OriginalPosLeft = DoorLeft.transform.position;
        OriginalPosRight = DoorRight.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Collided with" + other.gameObject.name);
            Move = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Move = false;
        }
    }

    void FixedUpdate()
    {
        if (Move)
        {
            DoorRight.transform.position = Vector3.Lerp(DoorRight.transform.position, RightTarget, smoothTime);
            DoorLeft.transform.position = Vector3.Lerp(DoorLeft.transform.position, LeftTarget, smoothTime);
        }
        else
        {
            DoorRight.transform.position = Vector3.Lerp(DoorRight.transform.position, OriginalPosRight, smoothTime);
            DoorLeft.transform.position = Vector3.Lerp(DoorLeft.transform.position, OriginalPosLeft, smoothTime);
        }
    }
}