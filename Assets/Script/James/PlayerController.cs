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
    public static bool Mode = false;
    public GameObject Gun, aimCam, moveCam;
    [Header("Changes The Speed of low gravity in the air")]
    public float SlowDownTime;
    [Header("How much more you can jump in low gravity")]
    public float JumpMultiplier;
    [Header("How much sprint multiplies ordinary movement")]
    public float SpeedMultiplier;
    private bool CanChange = true;
    [Header("Duration of low gravity")]
    public bool CheckTimer = false;
    public float LowGravityDuration;
    public float MaxLowGravityDuration;
    [Header("Cooldown for low gravity")]
    public float CooldownLowGravity;
    public float MaxCooldownLowGravity;
    public bool ApplyCooldown;
    public float InputDelay = 0.5f;
    public Animator _animator;
    private bool isGrounded; 
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Change();
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
        //apply movement on fixedupdate as it is better for physics than update
        MovePlayer();
        

        /*if (Mathf.Abs(_rb.velocity.y) > 0.001f)
        {
            _animator.SetBool("isWalking", false);
        }*/


    }
    private void MovePlayer()
    {
        if (Mode == true)
        {
            //Camera relative movement. Player can move forward, backward and side to side with up down left and right on the joystick. Forward movement is always based on where the camera is looking.
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
        //Slows down time on low gravity. Not sure whether needed.
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

        //Sprint Option on left stick pressed in. Reverts to ordinary speed when left stick pressed is released.
        Gamepad gamepad = Gamepad.current;
        if (gamepad.leftStickButton.wasPressedThisFrame)
        {
            _speed *= SpeedMultiplier;

        }
        if (gamepad.leftStickButton.wasReleasedThisFrame)
        {
            _speed /= SpeedMultiplier;

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

        //Animator code. If there is no y velocity and input is detected play walking animation. If player is in the air play jumping animation.
        if (Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("isInAir", true);
            if (move.x != 0 || move.y != 0)
            {
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _rb.velocity = Vector3.zero;
                _animator.SetBool("isWalking", false);
            }
        }
        else
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isGrounded", false);
            _animator.SetBool("isInAir", false);



           /* timer += Time.deltaTime;
            if (timer < timerpassed)
            {
                _animator.SetBool("isJumping", true);
            }
            else
            {
               _animator.SetBool("isJumping", false);
            }*/
        }
            /*if (gamepad.aButton.wasPressedThisFrame)
            {
                

            }*/
        
        /*if (Mathf.Abs(_rb.velocity.y) > 10f)
        {
            _animator.SetBool("isJumping", false);
        }*/
       // print(isGrounded);

       /*Applies a timer to the length of low gravity. After time runs out a cooldown is applied not allowing
       the use of low gravity again until after timer. If x is pressed, you can deactivate low gravity and have the cooldwon applied*/
        if (CheckTimer)
        {
            LowGravityDuration += Time.deltaTime;
            CanChange = false;

            if (LowGravityDuration > MaxLowGravityDuration)
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0);
                _JumpForce /= JumpMultiplier;
                Nogravity = true;
                SlowTime = false;
                CheckTimer = false;
                LowGravityDuration = 0;
                ApplyCooldown = true;
            }
            if (LowGravityDuration > InputDelay)
            {
                if (gamepad.xButton.isPressed)
                {
                    LowGravityDuration = 0f;
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
            LowGravityDuration = 0;
            CooldownLowGravity += Time.deltaTime;

            if (CooldownLowGravity < MaxCooldownLowGravity)
            {
                CanChange = false;
            }
            if (CooldownLowGravity > MaxCooldownLowGravity)
            {
                CanChange = true;
                ApplyCooldown = false;
                CooldownLowGravity = 0;
            }
        }
    }
    public void OnPause()
    {
        //Pause the game by stopping time. Will later have UI.
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
        //If no velocity on players y axis apply a force to the y axis on A button pressed.
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
        //Changes players gravity to simulate low gravity. Applied on X button press.
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
