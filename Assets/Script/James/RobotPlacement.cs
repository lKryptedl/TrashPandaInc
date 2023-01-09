using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotPlacement : MonoBehaviour
{
    public float timer = 5, timer2, countdown = 60;
    public Vector3 TargetLocation;
    public int random = 1, count = 0;
    private float y;
    public static int PlayersLocation = 1; //1 = Bridge , 2 = Lounge
    public GameObject robot, RobotWarning;
    public bool placing = false;

    public void Update()
    {
        if (PlayerController.Pause) //only run when game isnt paused
        {
            if (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
            }
            else
            {
                Location();
            }
            if (timer2 > 0 && placing == true)
            {
                timer2 -= Time.fixedDeltaTime;
            }
            else if (timer2 < 0 && placing == true)
            {
                Place();
            }
        }
    }

    public void Location()
    {
        while (PlayersLocation == random)
        {
            random = Random.Range(1, 3);
        }
        if (random == 1)
        {
            transform.position = new Vector3(205, 1, -15); //bridge location
        }
        else if (random == 2)
        {
            transform.position = new Vector3(375, -8, 180); //lounge location
        }
        TargetLocation = Random.insideUnitSphere * 150f + transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(TargetLocation, out hit, 5f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            if (count < 5)
            {
                timer = 1f;
                timer2 = 0.5f;
                placing = true;
            }
            else
            {
                count = 0;
                timer = countdown;
                RobotWarning.SetActive(true);
                RobotWarning.GetComponent<DialogueAlt>().Display(random);
            }

        }
    }
    public void Place()
    {
        if (random == RobotLocation.PlaceLocation)
        {
            Instantiate(robot, transform.position, transform.rotation);
            Score.RobotsLeft++;
            count++;
        }
        placing = false;
    }
}
