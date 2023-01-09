using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateDoorsDouble : MonoBehaviour
{

    public float smoothTime;
    public Transform DoorLeft,DoorRight;
    public bool Move;
    private Vector3 TargetLeft,TargetRight, OriginalPosLeft,OriginalPosRight;
    public Vector3 MovementDirLeft, MovementDirRight;
    private void Start()
    {
        OriginalPosLeft = DoorLeft.transform.position;
        OriginalPosRight = DoorRight.transform.position;
        TargetLeft = OriginalPosLeft + MovementDirLeft;
        TargetRight = OriginalPosRight + MovementDirRight;
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
            DoorLeft.transform.position = Vector3.Lerp(DoorLeft.transform.position, TargetLeft, smoothTime);
            DoorRight.transform.position = Vector3.Lerp(DoorRight.transform.position, TargetRight, smoothTime);
        }
        else
        {
            DoorLeft.transform.position = Vector3.Lerp(DoorLeft.transform.position, OriginalPosLeft, smoothTime);
            DoorRight.transform.position = Vector3.Lerp(DoorRight.transform.position, OriginalPosRight, smoothTime);
        }
    }
}