using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportLocation;
    [SerializeField] private float AdditionalX;
    public bool Teleported = false;
    StopInputAfterTeleport StopTeleport;

    private void Start()
    {
        GameObject HasTeleported = GameObject.FindGameObjectWithTag("GameManager");
        StopTeleport = HasTeleported.GetComponent<StopInputAfterTeleport>();
    }

    private void Update()
    {
        //print(Teleported);
    }

    void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player")) return;

        TeleportMethod(player);
        StopTeleport.isTeleported = true;

    }
    void TeleportMethod(Collider player)
    {
        print("Teleport");
        //player.transform.SetPositionAndRotation(TeleportLocation.position + new Vector3(AdditionalX, 0f, 0f); //TeleportLocation.rotation);
        player.transform.position = TeleportLocation.position + new Vector3(AdditionalX, 0f, 0f);

    }

}
