using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateDoors : MonoBehaviour
{

    public float smoothTime;
    public Transform Door;
    public bool Move;
    private Vector3 Target, OriginalPos;
    public Vector3 MovementDir;
    private void Start()
    {
        OriginalPos = Door.transform.position;
        Target = OriginalPos + MovementDir;
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
            Door.transform.position = Vector3.Lerp(Door.transform.position, Target, smoothTime);
        }
        else
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, OriginalPos, smoothTime);
        }
    }
}