using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 500f;
    [SerializeField] private float _JumpForce;
    public bool AllowInput = true;
    public bool Pause = true;
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
    public GameObject Gun, aimCam, moveCam, Reactor;
    [Header("Changes The Speed of low gravity in the air")]
    public float SlowDownTime;
    [Header("How much more you can jump in low gravity")]
    public float JumpMultiplier;
    [Header("How much sprint multiplies ordinary movement")]
    public float RunSpeed;
    private float walkSpeed;
    private bool CanChange = true;
    [Header("Duration of low gravity")]
    public bool CheckTimer = false;
    public float LowGravityDuration;
    public float MaxLowGravityDuration;
    [Header("Cooldown for low gravity")]
    public float CooldownLowGravity;
    public float MaxCooldownLowGravity;
    public bool ApplyCooldown;
    public bool Sprint;
    public float InputDelay = 0.5f;
    public Animator _animator;
    private bool OnGround;
    public float pause;
    public static bool canjump;
    [Header("Drag for ground and air")]
    public float grounddrag;
    public float airdrag;
    [Header("Reactor")]
    public float distance = 50;
    public float maxReactorDistance;
    public float countdown;
    [Header("Spherecast for if player is looking at button")]
    public float radius;
    public static bool ButtonHit = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        walkSpeed = _speed;
        Change();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            OnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            OnGround = false;
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
        if (DialogueTrigger.DialogueShowing == false)
        {
            MovePlayer();
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
            //Camera relative movement. Player can move forward, backward and side to side with up down left and right on the joystick. Forward movement is always based on where the camera is looking.
            Vector3 ForwardMovement = Camera.main.transform.forward;
            Vector3 RightMovement = Camera.main.transform.right;
            ForwardMovement.y = 0;
            RightMovement.y = 0;
            Vector3 ForwardMovementY = move.y * ForwardMovement;
            Vector3 ForwardMovementX = move.x * RightMovement;
            Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
            //_rb.AddForce(_speed * 10 * MovementBasedOnCamera.normalized, ForceMode.Impulse);
            //_rb.MovePosition(transform.position + MovementBasedOnCamera.normalized * Time.deltaTime * _speed);
            _rb.velocity = _speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized + new Vector3(0, _rb.velocity.y, 0);
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
            // _rb.AddForce(MovementBasedOnCamera.normalized * _speed * 10, ForceMode.Force);
            //_rb.MovePosition(transform.position + MovementBasedOnCamera.normalized * Time.deltaTime * _speed);
            _rb.velocity = _speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized + new Vector3(0, _rb.velocity.y, 0);
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
        if (OnGround)
        {
            _rb.drag = grounddrag;
        }
        else
        {
            _rb.drag = airdrag;
        }
        //print(Time.timeScale);
        //Sprint Option on left stick pressed in. Reverts to ordinary speed when left stick pressed is released.
        Gamepad gamepad = Gamepad.current;
        if (Pause)
        {
            if (gamepad == null)
            {
                print("Pause as no controller detected");
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
        if (!Pause)
        {
            Time.timeScale = 0;
        }
        if (Sprint)
        {
            _speed = RunSpeed;
            if (move.x == 0 && move.y == 0)
            {
                print("Walk speed");
                Sprint = false;
            }
        }
        if (!Sprint)
        {
            _speed = walkSpeed;
        }
        if (DialogueTrigger.DialogueShowing)
        {
            _rb.velocity = Vector3.zero;
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("isInAir", true);
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
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            canjump = true;
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("isInAir", true);
            if (!DialogueTrigger.DialogueShowing)
            {
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

        }
        if (Mathf.Abs(_rb.velocity.y) > 0.5f)
        {
            canjump = false;
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isGrounded", false);
            _animator.SetBool("isInAir", false);
        }
        if (canjump)
        {
            _animator.SetBool("isJumping", false);
        }

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
        if (SceneManager.GetActiveScene().name == "ReactorBridgeBlockout")
        {
            distance = Vector3.Distance(Reactor.transform.position, transform.position);
        }
        if (ApplyCooldown)
        {
            LowGravityDuration = 0;
            if (SceneManager.GetActiveScene().name == "ReactorBridgeBlockout")
            {
                distance = Vector3.Distance(Reactor.transform.position, transform.position);
                if (distance < maxReactorDistance)
                {
                    countdown = Time.deltaTime / (maxReactorDistance - distance);
                    countdown = Mathf.Clamp(countdown, 0.0005f, Time.deltaTime);
                }
                else
                {
                    countdown = Time.deltaTime;
                }
            }
            else
            {
                countdown = Time.deltaTime;
            }
            CooldownLowGravity += countdown;
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
            Pause = false;
        }
        else
        {
            Pause = true;
        }
    }
    public void OnSprint()
    {
        if (Sprint)
        {
            Sprint = false;
        }
        else
        {
            Sprint = true;
        }
    }
    public void OnJump()
    {
        //If no velocity on players y axis apply a force to the y axis on A button pressed.
        if (DialogueTrigger.DialogueShowing == false)
        {
            if (canjump)
            {
                //_animator.SetBool("isWalking", false);
                //_animator.SetBool("isJumping", true);
                //Vector3 Jump = new(0f, _JumpForce);
                _rb.AddForce(Vector3.up * _JumpForce);
            }
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
    public void Change()
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
