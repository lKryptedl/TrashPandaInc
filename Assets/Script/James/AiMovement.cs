using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    public NavMeshAgent Agent;
    public bool Moving;
    public Vector3 TargetLocation;
    public GameObject rubbish, spawnPoint, Player;
    private float y;
    public int health = 2;
    public int distance = 100;

    void Update()
    {
        if (Moving == false)
        {
            RandomLocation();
        }
        else if (Moving == true)
        {
            Agent.destination = TargetLocation;
            if (Mathf.Approximately(1.0f, TargetLocation.x / transform.position.x) && Mathf.Approximately(1.0f, TargetLocation.z /transform.position.z))
            {
                Instantiate(rubbish, spawnPoint.transform.position, spawnPoint.transform.rotation);
                Moving = false;
            }
        }
    }

    public void RandomLocation()
    { 
        if (Vector3.Distance(Player.transform.position, transform.position) < distance)
        {
            y = transform.position.y;
            TargetLocation = Random.insideUnitSphere * 40f + transform.position;
            TargetLocation.y = y;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(TargetLocation, out hit, 1.0f, NavMesh.AllAreas))
            {
                TargetLocation = hit.position;
                Moving = true;
            }
        }
    }

    void OnTriggerEnter(Collider other) //Rubbish hits robot
    {
        if (other.CompareTag("Rubbish") && other.GetComponent<Rigidbody>().velocity.magnitude > 2)
        {
            Shooting.Balls.Remove(other.gameObject);
            Destroy(other.gameObject);
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
                Score.PlayerScore += 500;
            }
        }
    }
}
