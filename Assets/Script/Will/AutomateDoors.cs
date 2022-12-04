using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateDoors : MonoBehaviour
{
    public Transform player;
    public MeshRenderer Mesh;
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 5)
        {
            Mesh.enabled = false;
        }
        else
        {
            Mesh.enabled = true;
        }
    }
}
