using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public int RubbishStored = 5;
    public bool suck = false;

    public int shotSpeed = 20;
    public int rocketCount = 10;
    public Rigidbody rubbish, rocket;

    RaycastHit Data;
    bool Hit;
    public static List<GameObject>  Balls = new List<GameObject>();
    GameObject Remove;
    public GameObject Player;

    void Update()
    {
        if (suck)
        {
            if (RubbishStored < 11)
            {
                foreach (GameObject body in Balls)
                {
                    body.GetComponent<Rigidbody>().AddForce((transform.position - body.transform.position) * 125f * Time.fixedDeltaTime);
                    if (Vector3.Distance(transform.position, body.transform.position) < 3)
                    {
                        body.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        body.transform.position = Vector3.Slerp(body.transform.position, transform.position, 10f * Time.fixedDeltaTime);
                    }
                    if (Vector3.Distance(transform.position, body.transform.position) < 1)
                    {
                        Remove = body;
                    }
                }
                if (Remove != null)
                {
                    Balls.Remove(Remove);
                    Destroy(Remove);
                    RubbishStored++;
                }
            }
            else
            {
                Debug.Log("Storage Full");
            }
        }
    }

    void OnShoot()
    {
        if (RubbishStored > 0)
        {
            Rigidbody shot = (Rigidbody)Instantiate(rubbish, transform.position, transform.rotation);
            shot.velocity = transform.forward * shotSpeed;
            RubbishStored--;
        }
        else
        {
            Debug.Log("No Rubbish");
        }
    }

    void OnSuck()
    {
        suck = !suck;
    }

    void OnRocket()
    {
        if (rocketCount > 0)
        {
            Rigidbody shot = (Rigidbody)Instantiate(rocket, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            shot.velocity = transform.forward * shotSpeed;
            shot.GetComponent<Rocket>().setObject(Player);
            rocketCount--;
        }
        else
        {
            Debug.Log("No Rockets Left");
        }
    }

    void OnTriggerEnter(Collider other) //Rubbish enters sucking range
    {
        if(other.CompareTag("Rubbish"))
        {
            Balls.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) //Rubbish leaves sucking range
    {
        if (other.CompareTag("Rubbish"))
        {
            Balls.Remove(other.gameObject);
        }
    }
}
