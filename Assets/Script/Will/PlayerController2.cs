using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    /*
      
     FIX FALLING IN SLOW MOTION, ADD A FLAG SO THAT IT ONLY WORKS WHEN JUMPING

    */
    //public bool Rotate = false;

    //private Quaternion _cameraTargetRot;
    private Rigidbody _rb;
    public float ChangeValue;
    [SerializeField] private float _speed;
    [SerializeField] private float _JumpForce;
    public bool AllowInput = true;
    private bool Pause = true;
    public bool FreezeConstraints = false;
    //private Animator _animator;
    PlayerControls controls;
    Vector3 move;
    //Vector3 EulerAngleVelocity;
    public bool SlowTime = false;
    public bool Nogravity = true;
    [Header("Gravity Change")]
    [Tooltip("Changes the gravity on k press, Original gravity is -9.81")]
    public float ChangeInGravity;
    public float originalMass = 1f;
    public float massChange = 0.7f;
    public float rotationSpeed = 100f;
    public Transform MovePosition;
    public bool Jump = false;
    public bool isGrounded = true;
    //public Transform PlayersBack;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        //_cameraTargetRot = CameraTransform.rotation;
        //EulerAngleVelocity = new Vector3(0, look.x, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
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
        //Physics.gravity = new Vector3(0f, -100f, 0);
        controls = new PlayerControls();
        //controls.Newactionmap.Enable();
        //_animator = GetComponent<Animator>();
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
        if (Jump)
        {
            if (isGrounded)
            {
                //_rb.AddForce(new Vector3(0f, _JumpForce, 0f), ForceMode.Impulse); //ForceMode.Impulse);
                _rb.AddForce(transform.up * _JumpForce);
                Jump = false;

            }
        }

        /*if (Gamepad.current.rightStick.right.isPressed)
        {
            transform.Rotate((transform.up * look.x) * rotationSpeed * Time.fixedDeltaTime);
        }
        if (Gamepad.current.rightStick.left.isPressed)
        {
            //Vector3 InvertRotation
            //transform.Rotate(0, -look.x, 0);
            transform.Rotate((transform.up / look.x) * rotationSpeed * Time.fixedDeltaTime);
        }
        if (Gamepad.current.rightStick.up.isPressed)
        {
            //_cameraTargetRot *= Quaternion.Euler(-look.y, 0f, 0f);
            //CameraTransform.Rotate((transform.up * look.y) * rotationSpeed * Time.fixedDeltaTime);
            GameObject RotateCamera = GameObject.FindGameObjectWithTag("MainCamera");
            CameraController RotateCameraScript = RotateCamera.GetComponent<CameraController>();
            RotateCameraScript.offset = new Vector3(0, 5, ChangeOffset);
            if(ChangeOffset < -2)
            {
                ChangeOffset += ChangeValue;
            }
            if (ChangeOffset < 4)
            {
                if (ChangeOffset < 10)
                {
                    ChangeOffset++;
                }
            }
            //CameraTransform.localRotation = _cameraTargetRot;
        }*/
        /* if (Gamepad.current.rightStick.down.isPressed)
         {
             print("Left");
             GameObject RotateCamera = GameObject.FindGameObjectWithTag("MainCamera");
             CameraController RotateCameraScript = RotateCamera.GetComponent<CameraController>();
             RotateCameraScript.offset = new Vector3(0, 5, ChangeOffset);
             if (ChangeOffset >-18)
             {
                 print("Move");
                 ChangeOffset -= ChangeValue;
             }
         }*/
        //else { return; }
        //_rb.velocity = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        //Vector3 Movement = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        //Movement.y = _rb.velocity.y;
        //_rb.velocity = Movement;
        //transform.Rotate((transform.up * move.x) * rotationSpeed * Time.fixedDeltaTime);

        //transform.eulerAngles += rotationSpeed * new Vector3(look.y, look.x, 0f);
        /*if (Rotate)
        {
            transform.Rotate(0, look.x, 0);
        }*/
        /*if (move != Vector3.zero)
        {
            transform.forward = move;
        }*/
        // _rb.AddForce(new Vector3(0f, 0f, move.y) * _speed * Time.fixedDeltaTime);;
        //move.Normalize();

    }
    private void MovePlayer()
    {
        //Vector3 inputDir = orientation.forward * move.y + orientation.right * move.x;
        //_rb.AddForce(inputDir.normalized * _speed * 10f, ForceMode.Force);
        // if (inputDir != Vector3.zero)
        //{
        //    playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        // }
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
        //Vector3 movement = new Vector3(move.x, 0.0f, move.y).normalized;
        /* if (movement != Vector3.zero)
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
         }
         _rb.AddForce(movement * _speed * Time.deltaTime, ForceMode.Force);*/
        /* if(movement == Vector3.zero)
         {
             return;
         }
         Quaternion targetRotation = Quaternion.LookRotation(movement);
         targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
         _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
         _rb.MoveRotation(targetRotation);*/
    }
    //public void OnLook()
    //{
    //Rotate = true;
    //print("Look");
    // _rb.MoveRotation
    //Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.fixedDeltaTime);
    //_rb.MoveRotation(_rb.rotation * deltaRotation);
    // transform.Rotate(0, look.x, 0);
    //}
    private void Update()
    {

        //HandleRotation();
        //print(Time.timeScale);
        //print(_JumpForce);
        //print(_rb.velocity.y);        
        //_animator.SetFloat("Speed", _rb.velocity.magnitude);
        //_rb.AddForce(new Vector3(move.x, 0f, move.y) * _speed, ForceMode.Force);

        //Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        //orientation.forward = viewDir.normalized;

        //_rb.AddForce(new Vector3(move.x, 0f, move.y) * _speed * Time.fixedDeltaTime);
        /*if (Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            SlowTime = false;
            Time.timeScale = 1f;
        }*/
        /* if (Nogravity)
         {
             if (Mathf.Abs(_rb.velocity.y) < 0.001f)
             {
                 SlowTime = true;
             }
         }*/
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
        /*if (FreezeConstraints)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    else
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }*/
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
    /*void HandleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(move.x, 0, move.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(PlayersBack);
    }*/
    public void OnJump()
    {
        Jump = true;

    }
    public void OnGravity()
    {
        SlowTime = true;
        if (Nogravity == true)
        {
            Physics.gravity = new Vector3(0f, ChangeInGravity, 0f);

            Time.timeScale = 1f;
            //_rb.mass = massChange;
            Nogravity = false;
            _JumpForce *= 2f;
            SlowTime = true;


        }
        else if (Nogravity == false)
        {
            Physics.gravity = new Vector3(0f, -9.81f, 0);
            //Time.timeScale = 1f;
            //_rb.mass = originalMass;
            _JumpForce /= 2f;
            SlowTime = false;
            Nogravity = true;
        }
    }
}
