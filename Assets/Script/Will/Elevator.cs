using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Elevator : MonoBehaviour
{
    public AudioSource AudioSourceLiftMusic;
    public bool OnPlatform = false;
    public GameObject PlatformElevator;
    public bool moveup = false;
    public bool movingup = true;
    public GameObject player;
    public GameObject platform;
    private Vector3 originalposition;
    public Vector3 upposition, bottomposition;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public static bool PlatformIsMovingUp = false;
    public static bool PlatformIsMovingDown = false;
    private void Start()
    {
        originalposition = PlatformElevator.transform.position;
        upposition.x = PlatformElevator.transform.position.x;
        upposition.z = PlatformElevator.transform.position.z;
        bottomposition.x = PlatformElevator.transform.position.x;
        bottomposition.z = PlatformElevator.transform.position.z;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (PlayerController.ButtonHit)
        {
            if (PlatformElevator.transform.position.y > bottomposition.y - 1 && PlatformElevator.transform.position.y < originalposition.y + 1)
            {
                PlatformIsMovingDown = false;
                PlatformIsMovingUp = true;
                PlayerController.ButtonHit = false;
            }
            if (PlatformElevator.transform.position.y > bottomposition.y + 1)
            {
                PlatformIsMovingUp = false;
                PlatformIsMovingDown = true;
                PlayerController.ButtonHit = false;
            }
        }
        //Vector3 newTarg = new(PlatformElevator.transform.position.x, PlatformElevator.transform.position.y - 30f, PlatformElevator.transform.position.z);    
        if (PlatformIsMovingUp)
        {
            print("Move Up");
            PlatformElevator.transform.position = Vector3.SmoothDamp(PlatformElevator.transform.position, originalposition, ref velocity, smoothTime);
            AudioSourceLiftMusic.Play();
            if (PlatformElevator.transform.position.y > originalposition.y - 0.2f)
            {
                print("Stop Moving UP");
                PlatformIsMovingUp = false;
                AudioSourceLiftMusic.Pause();

            }
        }
        if (PlatformIsMovingDown)
        {
            print("move Down");
            AudioSourceLiftMusic.Play();

            if (PlatformElevator.transform.position.y < bottomposition.y + 0.2f)
            {
                print("Stop Moving DOwn");
                PlatformIsMovingDown = false;
                AudioSourceLiftMusic.Pause();

            }
            PlatformElevator.transform.position = Vector3.SmoothDamp(PlatformElevator.transform.position, bottomposition, ref velocity, smoothTime);
        }

    }
}
