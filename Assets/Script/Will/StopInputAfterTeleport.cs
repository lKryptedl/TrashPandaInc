using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopInputAfterTeleport : MonoBehaviour
{
    private float TimeElapsed;
    private float MaxTime = 2f;
    PlayerController FreezeInput;
    public bool isTeleported;
    private void Start()
    {
        GameObject StopMovement = GameObject.Find("Racoon");
        FreezeInput = StopMovement.GetComponent<PlayerController>();
    }

    void Update()
    {
        //print("Time"); print(TimeElapsed);
        //GameObject HasTeleported = GameObject.FindGameObjectWithTag("GameManager");
        //Teleport HasTeleportedScript = HasTeleported.GetComponent<Teleport>();
        //if (HasTeleportedScript.Teleported == true)
        if (isTeleported)
        {
            TimeElapsed += Time.deltaTime;
            if (TimeElapsed > MaxTime)
            {
                GameObject Teleporter = GameObject.FindGameObjectWithTag("Teleporter");
                Teleport TeleportScript = Teleporter.GetComponent<Teleport>();
                isTeleported = false;
                FreezeInput.FreezeConstraints = false;
                TimeElapsed = 0f;
                //TimeElapsed = 0f;
            }
            else
            {
                FreezeInput.FreezeConstraints = true; //= new Vector3(0f,0f,0f);
                //TimeElapsed = 0f;

            }
        }
        else
        {
            return;
        }
    }
}
