using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateDoors : MonoBehaviour
{
    public Transform player;
    public MeshRenderer Mesh;
    public Collider Collision;
    public float minDistance;
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < minDistance)
        {
            Mesh.enabled = false;
            Collision.enabled = false;
        }
        else
        {
            Mesh.enabled = true;
            Collision.enabled = true;
        }
    }
}
