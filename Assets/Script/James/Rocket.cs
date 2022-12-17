using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rubbish, Player;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BigRubbish")) //Destroys big rubbish
        {
            Destroy(other.gameObject);
            for (int x = 0; x < 4; x++)
            {
                Instantiate(rubbish, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Robot")) //Destroys robot
        {
            Destroy(other.gameObject);
            Score.PlayerScore += 500;
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) //Collision destroying rocket
        {
            if ((Vector3.Distance(Player.transform.position, transform.position) < 20) && PlayerController.OnGround == false) 
            {
                Vector3 direction = Player.transform.position - transform.position;
                direction.Normalize();
                Player.GetComponent<Rigidbody>().AddForce(direction * 5000f);
            }
            Destroy(gameObject);
        }
    }
    public void setObject(GameObject player)
    {
        Player = player;
    }
}
