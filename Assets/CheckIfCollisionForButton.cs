using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckIfCollisionForButton : MonoBehaviour
{
    public Transform player, Button;
    public float angle;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!Elevator.PlatformIsMovingDown && !Elevator.PlatformIsMovingUp)
            {
                Gamepad controller = Gamepad.current;
                /*var Target = (Button.position - player.position).normalized;
                Target.y = 0;
                print(Vector3.Dot(transform.forward, Target));*/
                print(Vector3.Angle(player.transform.forward, Button.position - player.transform.position));
                if (Vector3.Angle(player.transform.forward, Button.position - player.transform.position) < angle)
                {
                    if (controller.yButton.isPressed)
                    {
                        print("Hit");
                        PlayerController.ButtonHit = true;
                    }
                }
                // if (Vector3.Dot(transform.forward, Target) < 0)
                //  {
                
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
