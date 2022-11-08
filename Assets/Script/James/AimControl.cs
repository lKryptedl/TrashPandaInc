using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
    ShootingControls controls;
    Vector3 aim, rotate, rotateChange;
    int maxRotate = 25;
    int minRotate = -25;

    public GameObject hitMarker, shotPoint, Player;
    public LayerMask Ignore;
    void Awake()
    {
        controls = new ShootingControls();
        controls.Control.Enable();
        controls.Control.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        controls.Control.Aim.canceled += ctx => aim = Vector2.zero;
    }
    
    void FixedUpdate()
    {
        rotateChange = new Vector3(aim.y * -1.5f, aim.x * 1.5f, 0);
        rotate += rotateChange;
        rotate.x = Mathf.Clamp(rotate.x, minRotate, maxRotate);
        rotate.y = Mathf.Clamp(rotate.y, minRotate, maxRotate);
        transform.localEulerAngles = rotate;

        RaycastHit hit;
        if (Physics.Raycast(shotPoint.transform.position, transform.forward, out hit, 5, ~Ignore))
        {
            hitMarker.transform.position = hit.point;
            hitMarker.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            hitMarker.transform.position = shotPoint.transform.position + transform.forward * 5;
            hitMarker.GetComponent<Renderer>().material.color = Color.white;
        }
        /*
        if (rotate.y == maxRotate && aim.x != 0)
        {
            Player.transform.Rotate((Player.transform.up * 0.5f) * PlayerController.rotationSpeed * Time.fixedDeltaTime);
            hitMarker.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (rotate.y == minRotate && aim.x != 0)
        {
            Player.transform.Rotate((Player.transform.up * -0.5f) * PlayerController.rotationSpeed * Time.fixedDeltaTime);
            hitMarker.GetComponent<Renderer>().material.color = Color.blue;
        }
        */
    }

    void OnResetAim()
    {
        rotate = new Vector3(0f, 0f, 0f); ;
    }
}
