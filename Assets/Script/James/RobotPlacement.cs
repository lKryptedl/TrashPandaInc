using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotPlacement : MonoBehaviour
{
    public float timer = 5, timer2, countdown = 60;
    public Vector3 TargetLocation;
    public int random = 1, count = 0, randrobo;
    private int prevRand;
    private float y;
    public static int PlayersLocation; //1 = Bridge , 2 = Lounge
    public GameObject robot, flyrobot, RobotWarning;
    public bool placing = false;
    private bool randomised = false;

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
        if (randomised == false)
        {
            prevRand = random;
            random = Random.Range(1, 5);
            randomised = true;
        }
        if (PlayersLocation == random || prevRand == random)
        {
            while (PlayersLocation == random || prevRand == random)
            {
                random = Random.Range(1, 5);
            }
            randomised = true;
        }
        if (random == 1)
        {
            transform.position = new Vector3(205, 1, -15); //bridge location
        }
        else if (random == 2)
        {
            transform.position = new Vector3(375, -8, 180); //lounge location
        }
        else if (random == 3)
        {
            transform.position = new Vector3(390, -112, 415); //Depot location
        }
        else if (random == 4)
        {
            transform.position = new Vector3(15, -160, 155); //Reactor location
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
                randomised = false;
                RobotWarning.SetActive(true);
                RobotWarning.GetComponent<DialogueAlt>().Display(random);
            }

        }
    }
    public void Place()
    {
        if (random == RobotLocation.PlaceLocation)
        {
            randrobo = Random.Range(1, 3);
            if (randrobo == 1)
            {
                Instantiate(robot, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(flyrobot, transform.position, transform.rotation);
            }
            Score.RobotsLeft++;
            count++;
        }
        placing = false;
    }
}
