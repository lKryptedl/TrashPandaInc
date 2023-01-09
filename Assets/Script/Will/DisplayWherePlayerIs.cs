using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWherePlayerIs : MonoBehaviour
{
    private Transform playerLocation;
    private Vector3 BridgePos = new(-4.80000019f, 29.2000008f, 0), CorridorPos = new(-4.19999981f, 1.29999995f, 0), LoungePos = new(-29.2999992f, 4.69999981f, 0), DepotPos = new(-28.3999996f, -22.5f, 0), ReactorPos = new(26.3999996f, 1.29999995f, 0), JustBeforeDepot = new(-4.0999999f, -26.2000008f, 0);
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Beans").GetComponent<Transform>();
        transform.localPosition = BridgePos;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLocation.position.z < 70 && playerLocation.position.x < 387f && playerLocation.position.x > 26 && playerLocation.position.y < 30)
        {
            print("Bridge");
            if (transform.localPosition != BridgePos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, BridgePos, smooth);
            }
        }
        if (playerLocation.position.z > 70 && playerLocation.position.z < 382.1f && playerLocation.position.x > 195 && playerLocation.position.x < 241)
        {
            print("Corridor");
            if (transform.localPosition != CorridorPos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, CorridorPos, smooth);
            }
        }
        else if (playerLocation.position.x > 247 && playerLocation.position.x < 500 && playerLocation.position.z > 65 && playerLocation.position.z < 259)
        {
            print("Lounge");
            if (transform.localPosition != LoungePos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, LoungePos, smooth);
            }
        }
        else if (playerLocation.position.x > 302.06 && playerLocation.position.z > 328 && playerLocation.position.z < 470 && playerLocation.position.y < -50f)
        {
            if (transform.localPosition != DepotPos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, DepotPos, smooth);
            }
            print("Depot");
        }
        else if (playerLocation.position.x < 295 && playerLocation.position.z > 382.5567f && playerLocation.position.z < 437.4745)
        {
            if (transform.localPosition != JustBeforeDepot)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, JustBeforeDepot, smooth);
            }
        }
        else if (playerLocation.position.x > -24.86115f && playerLocation.position.x < 55 && playerLocation.position.z < 380)
        { 
            if (transform.localPosition != ReactorPos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, ReactorPos, smooth);
            }
        }
    }
}
