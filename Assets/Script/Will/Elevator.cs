using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Elevator : MonoBehaviour
{
    public bool OnPlatform = false;
    public float platformspeed;
    public GameObject PlatformElevator;
    public bool moveup = false;
    public bool movingup = true;
    public GameObject player;
    public GameObject platform;
    public Vector3 originalposition;
    public Vector3 upposition;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public bool PlatformIsMovingUp = false;
    public bool PlatformIsMovingDown = false;
    // Update is called once per frame

    void FixedUpdate()
    {
        if (PlayerController.ButtonHit)
        {
            if (PlatformElevator.transform.position.y > originalposition.y - 1 && PlatformElevator.transform.position.y < upposition.y + 1)
            {
                PlatformIsMovingDown = false;
                PlatformIsMovingUp = true;
                PlayerController.ButtonHit = false;
            }
            if (PlatformElevator.transform.position.y > originalposition.y + 1)
            {
                PlatformIsMovingUp = false;
                PlatformIsMovingDown = true;
                PlayerController.ButtonHit = false;
            }
        }
        if (PlatformIsMovingUp)
        {
            PlatformElevator.transform.position = Vector3.SmoothDamp(PlatformElevator.transform.position, upposition, ref velocity, smoothTime);
        }
        if (PlatformIsMovingDown)
        {
            PlatformElevator.transform.position = Vector3.SmoothDamp(PlatformElevator.transform.position, originalposition, ref velocity, smoothTime);
        }

    }
}
