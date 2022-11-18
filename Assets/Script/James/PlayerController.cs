using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
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
    public Transform MovePosition;
    public bool Jump = false;
    public bool isGrounded = true;
    public bool Mode = false;
    public GameObject Camera1, Camera2, Gun, Sphere;
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
            ForwardMovement = ForwardMovement.normalized;
            RightMovement = RightMovement.normalized;
            Vector3 ForwardMovementY = move.y * ForwardMovement;
            Vector3 ForwardMovementX = move.x * RightMovement;
            Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
            _rb.AddForce(MovementBasedOnCamera * _speed * Time.fixedDeltaTime, ForceMode.Force);
            if (MovementBasedOnCamera == Vector3.zero)
            {
                return;
            }
            Quaternion targetRotation = Quaternion.LookRotation(MovementBasedOnCamera);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
            _rb.MoveRotation(targetRotation);
        }
        else
        {
            Vector3 Movement = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
            Movement.y = _rb.velocity.y;
            _rb.velocity = Movement;
            transform.Rotate((transform.up * move.x) * rotationSpeed * Time.fixedDeltaTime);
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
    private void OnChange()
    {
        Change();
    }
    void Change()
    {
        Mode = !Mode;
        if (Mode == true)
        {
            _speed = 1000f;
            Gun.GetComponent<AimControl>().OnAimReset();
            Gun.GetComponent<AimControl>().enabled = false;
            Camera2.SetActive(false);
            Camera1.SetActive(true);
            Sphere.SetActive(false);
        }
        else
        {
            _speed = 300f;
            Gun.GetComponent<AimControl>().enabled = true;
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Sphere.SetActive(true);
        }
        Debug.Log(Mode);
    }
}
