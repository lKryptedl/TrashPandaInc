using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckIfCollisionForButton : MonoBehaviour
{
    public Transform player;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!Elevator.PlatformIsMovingDown && !Elevator.PlatformIsMovingUp)
            {
                Gamepad controller = Gamepad.current;
                //var Target = player.position - gameObject.transform.position;
                //print(Vector3.Dot(transform.forward, Target));
               // if (Vector3.Dot(transform.forward, Target) < 0)
              //  {
                    if (controller.yButton.isPressed)
                    {
                        print("Hit");
                        PlayerController.ButtonHit = true;
                    }
              //  }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.ButtonHit = false;
        }
    }
}
