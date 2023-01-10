using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public static int RubbishStored = 5;
    public bool suck = false;
    private bool shooting;

    public int shotSpeed = 20;
    public int rocketCount = 10;
    public Rigidbody rubbish, rocket;

    RaycastHit Data;
    bool Hit;
    public static List<GameObject>  Balls = new List<GameObject>();
    GameObject Remove;
    public GameObject Player;
    public AudioSource suckSound, shootSound, suckStart, suckEnd;
    private bool suckRevved = false;
    public TMP_Text RocketDisplay;
    void Update()
    {
        RocketDisplay.text = rocketCount.ToString();
        if (suck == true)
        {
            if (RubbishStored < 12)
            {
                if (!suckStart.isPlaying && suckRevved == false)
                {
                    suckStart.Play();
                    suckRevved = true;
                }
                if (!suckSound.isPlaying && !suckStart.isPlaying && suckRevved == true)
                {
                    suckSound.Play();
                }
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
                    Score.rubbishLeft--;
                }
            }
            else
            {
                Debug.Log("Storage Full");
            }
        }
        if (suck == false)
        {
            if (suckRevved == true && !suckStart.isPlaying)
            {
                suckStart.Stop();
                suckSound.Stop();
                suckEnd.Play();
                suckRevved = false;
            }
            else
            {
                suckStart.Stop();
                suckRevved = false;
            }

        }
    }

    void OnShoot()
    {
        if (suck == false)
        {
            if (RubbishStored > 0)
            {
                shootSound.Play();
                Rigidbody shot = (Rigidbody)Instantiate(rubbish, transform.position, transform.rotation);
                shot.velocity = transform.forward * shotSpeed;
                RubbishStored--;
                Score.rubbishLeft++;
            }
            else
            {
                Debug.Log("No Rubbish");
            }
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
            Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
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
