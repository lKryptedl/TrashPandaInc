using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 500f;
    [SerializeField] private float _JumpForce;
    public bool AllowInput = true;
    private bool Pause = true;
    public bool FreezeConstraints = false;
    PlayerControls controls;
    Vector3 move;
    public bool SlowTime = false;
    public bool Nogravity = true;
    [Header("Gravity Change")]
    [Tooltip("Changes the gravity on k press, Original gravity is -9.81")]
    public float ChangeInGravity;
    public float rotationSpeed = 100f;
    public Transform MovePosition, FollowPoint;
    public bool Jump = false;
    public bool isGrounded = true;
    public static bool Mode = false;
    public GameObject Gun, aimCam, moveCam;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Change();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
            Jump = false;
        }
    }
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Newactionmap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Move.canceled += ctx => move = Vector2.zero;
    }
    private void OnEnable()
    {
         controls.Newactionmap.Enable();
    }
    private void OnDisable()
    {
         controls.Newactionmap.Disable();
    }
    private void FixedUpdate()
    {
        
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (Mode == true)
        {
            Vector3 ForwardMovement = Camera.main.transform.forward;
            Vector3 RightMovement = Camera.main.transform.right;
            ForwardMovement.y = 0;
            RightMovement.y = 0;
            Vector3 ForwardMovementY = move.y * ForwardMovement;
            Vector3 ForwardMovementX = move.x * RightMovement;
            Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
            _rb.AddForce(MovementBasedOnCamera * _speed * Time.fixedDeltaTime, ForceMode.Force);
            
            if (MovementBasedOnCamera == Vector3.zero)
            {
                return;
            }
            Quaternion targetRotation = FollowPoint.rotation;
            targetRotation.z = 0;
            targetRotation.x = 0;
            _rb.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15 * Time.fixedDeltaTime);
            /*
            Quaternion targetRotation = Quaternion.LookRotation(MovementBasedOnCamera);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
            _rb.MoveRotation(targetRotation);
            */

        }
        else
        {
            Vector3 ForwardMovement = Camera.main.transform.forward;
            Vector3 RightMovement = Camera.main.transform.right;
            ForwardMovement.y = 0;
            RightMovement.y = 0;
            Vector3 ForwardMovementY = move.y * ForwardMovement;
            Vector3 ForwardMovementX = move.x * RightMovement;
            Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
            _rb.AddForce(MovementBasedOnCamera * _speed * Time.fixedDeltaTime, ForceMode.Force);
        }
        
    }
    private void Update()
    {
        if (SlowTime)
        {
            if (Mathf.Abs(_rb.velocity.y) < 0.001f)
            {
                Time.timeScale = 1f;
            }
            if (Mathf.Abs(_rb.velocity.y) > 0.001f)
            {
                Time.timeScale = 0.8f;
                print("Change Time");
            }
        }
        if (!SlowTime)
        {
            Time.timeScale = 1f;
        }
    }
    public void OnPause()
    {
        if (Pause)
        {
            Time.timeScale = 0f;
            Pause = false;
        }
        else
        {
            Time.timeScale = 1f;
            Pause = true;
        }
    }
    public void OnJump()
    {
            if(Mathf.Abs(_rb.velocity.y) < 0.0001f)
        {
            Vector3 Jump = new(0f, _JumpForce);
            _rb.AddForce(Jump);
        }
    }
    public void OnGravity()
    {
        SlowTime = true;
        if (Nogravity == true)
        {
            Physics.gravity = new Vector3(0f, ChangeInGravity, 0f);
            
                Time.timeScale = 1f;
            Nogravity = false;
            _JumpForce *= 2f;
            SlowTime = true;
            
            
        }
        else if (Nogravity == false)
        {
            Physics.gravity = new Vector3(0f, -9.81f, 0);
            _JumpForce /= 2f;
            SlowTime = false;
            Nogravity = true;
        }
    }
    void OnChange()
    {
        Change();
    }
    void Change()
    {
        Mode = !Mode;
        if (Mode == true)
        {
            Gun.transform.rotation = transform.rotation;
            moveCam.SetActive(true);
            aimCam.SetActive(false);
        }
        else
        {
            aimCam.SetActive(true);
            moveCam.SetActive(false);
        }
    }
}
