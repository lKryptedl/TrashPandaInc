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
    Vector2 move;
    public bool SlowTime = false;
    public bool Nogravity = true;
    [Header("Gravity Change")]
    [Tooltip("Changes the gravity on k press, Original gravity is -9.81")]
    public float ChangeInGravity;
    [Header("Player Rotation Speed")]
    [Tooltip("The speed of the players rotation when rotating the camera")]
    public float rotationSpeed;
    public Transform MovePosition, FollowPoint;
    // public bool Jump = false;
    // public bool isGrounded = true;
    public static bool Mode = false;
    public GameObject Gun, aimCam, moveCam;
    [Header("Changes The Speed of low gravity in the air")]
    public float SlowDownTime;
    [Header("How much more you can jump in low gravity")]
    public float JumpMultiplier;
    [Header("How much sprint multiplies ordinary movement")]
    public float SpeedMultiplier;
    private bool CanChange = true;
    public bool CheckTimer = false;
    public float Timer;
    public float TimerPassed;
    public float Timer2;
    public float TimerPassed2;
    public bool ApplyCooldown;
    public float InputDelay = 0.5f;
    public Animator _animator;
    private bool isGrounded;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Change();
        Timer = 0f;
        Timer2 = 0f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = false;
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
        if (Mathf.Abs(_rb.velocity.y) < 0.0001f)
        {
            if (move.x == -1 || move.x == 1 || move.y == -1 || move.y == 1)
            {
                _animator.SetBool("isWalking", true);

            }
            if (move.x == 0 && move.y == 0)
            {
                _rb.velocity = Vector3.zero;
                _animator.SetBool("isWalking", false);
            }
        }

        /*if (Mathf.Abs(_rb.velocity.y) > 0.001f)
        {
            _animator.SetBool("isWalking", false);
        }*/
        

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
            _rb.AddForce(_speed * Time.fixedDeltaTime * MovementBasedOnCamera, ForceMode.Force);

            if (MovementBasedOnCamera == Vector3.zero)
            {
                return;
            }
            Quaternion targetRotation = FollowPoint.rotation;
            targetRotation.z = 0;
            targetRotation.x = 0;
            _rb.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
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
                Time.timeScale = SlowDownTime;
            }
        }
        if (!SlowTime)
        {
            Time.timeScale = 1f;
        }
        Gamepad gamepad = Gamepad.current;
        if (gamepad.leftStickButton.wasPressedThisFrame)
        {
            _speed *= SpeedMultiplier;
        }
        if (gamepad.leftStickButton.wasReleasedThisFrame)
        {
            _speed /= SpeedMultiplier;
        }
        /*if (gamepad.aButton.isPressed)
        {
            print("A Pressed");
            _animator.SetBool("isWalking", false);
        }*/
        if (Mathf.Abs(_rb.velocity.y) > 0.01f)
        {
            _animator.SetBool("isWalking", false);
            //_animator.SetBool("isJumping", true);
        }
        /*if (gamepad.leftStick.left.isPressed || gamepad.leftStick.right.isPressed || gamepad.leftStick.up.isPressed || gamepad.leftStick.down.isPressed)
        {
            //print("Animation Play");
            //_animator.SetBool("isWalking", true);

        }
        if (gamepad.leftStick.left.wasReleasedThisFrame || gamepad.leftStick.right.wasReleasedThisFrame || gamepad.leftStick.up.wasReleasedThisFrame || gamepad.leftStick.down.wasReleasedThisFrame)
        {
            _rb.velocity = Vector3.zero;
        }*/
        //print(_rb.velocity.y);
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            _animator.SetBool("isJumping", false);
            if (gamepad.aButton.wasPressedThisFrame)
            {
                print("X");
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isJumping", true);
            }
        }
        if(Mathf.Abs(_rb.velocity.y) > 10f)
        {
<<<<<<< Updated upstream
=======
            _animator.SetBool("isJumping", false);
        }
        print(isGrounded);

        /*if (isGrounded)
        {
>>>>>>> Stashed changes
            if (_rb.velocity.magnitude > 0)
            {
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _animator.SetBool("isWalking", false);
            }
        }*/
        if (CheckTimer)
        {

            Timer += Time.deltaTime;
            CanChange = false;

            if (Timer > TimerPassed)
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0);
                _JumpForce /= JumpMultiplier;
                Nogravity = true;
                SlowTime = false;
                CheckTimer = false;
                Timer = 0;
                ApplyCooldown = true;
            }
            if (Timer > InputDelay)
            {
                if (gamepad.xButton.isPressed)
                {
                    Timer = 0f;
                    Physics.gravity = new Vector3(0f, -9.81f, 0);
                    _JumpForce /= JumpMultiplier;
                    Nogravity = true;
                    SlowTime = false;
                    CheckTimer = false;
                    ApplyCooldown = true;

                }
            }
        }

        if (ApplyCooldown)
        {
            Timer = 0;
            Timer2 += Time.deltaTime;

            if (Timer2 < TimerPassed2)
            {
                CanChange = false;
            }
            if (Timer2 > TimerPassed2)
            {
                CanChange = true;
                ApplyCooldown = false;
                Timer2 = 0;
            }
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
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            //_animator.SetBool("isWalking", false);
            //_animator.SetBool("isJumping", true);
            Vector3 Jump = new(0f, _JumpForce);
            _rb.AddForce(Jump);
        }
    }
    public void OnGravity()
    {
        if (CanChange)
        {


            SlowTime = true;
            if (Nogravity == true)
            {
                Physics.gravity = new Vector3(0f, ChangeInGravity, 0f);

                Time.timeScale = 1f;
                Nogravity = false;
                _JumpForce *= JumpMultiplier;
                SlowTime = true;
                CheckTimer = true;
            }
            else if (Nogravity == false)
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0);
                _JumpForce /= JumpMultiplier;
                SlowTime = false;
                Nogravity = true;
                CheckTimer = false;
            }
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
