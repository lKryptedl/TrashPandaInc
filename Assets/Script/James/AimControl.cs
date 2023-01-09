using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
    public GameObject Player, shotPoint;
    public Transform followPoint;
    ShootingControls controls;
    Vector3 aim;
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    public Camera aimCamera;
    public float yaw;
    void Awake()
    {
        controls = new ShootingControls();
        controls.Control.Enable();
        controls.Control.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        controls.Control.Aim.canceled += ctx => aim = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (PlayerController.Mode == false)
        {
            xAxis.Update(Time.fixedDeltaTime);
            yAxis.Update(Time.fixedDeltaTime);
            xAxis.m_InputAxisValue = aim.x;
            yAxis.m_InputAxisValue = aim.y;
            followPoint.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
            transform.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
            yaw = aimCamera.transform.rotation.eulerAngles.y;
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, yaw, 0), 10 * Time.fixedDeltaTime);
        }
        else
        {
            xAxis.Update(Time.fixedDeltaTime);
            yAxis.Update(Time.fixedDeltaTime);
            xAxis.m_InputAxisValue = aim.x;
            yAxis.m_InputAxisValue = aim.y;
            transform.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
            followPoint.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        }
    }
}
