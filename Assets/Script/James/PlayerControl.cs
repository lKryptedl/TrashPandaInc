using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    /*
      
     FIX FALLING IN SLOW MOTION, ADD A FLAG SO THAT IT ONLY WORKS WHEN JUMPING

    */
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _JumpForce;
    public bool AllowInput = true;
    private bool Pause = true;
    public bool FreezeConstraints = false;
    private Animator _animator;
    PlayerControls controls;
    Vector3 move;
    public bool SlowTime = false;
    public bool Nogravity = true;
    [Header("Gravity Change")]
    [Tooltip("Changes the gravity on k press, Original gravity is -9.81")]
    public float ChangeInGravity;
    public float originalMass = 1f;
    public float massChange = 0.7f;
    public static float rotationSpeed = 100f;
    public Transform MovePosition;
    public bool Jump = false;
    public bool isGrounded = true;

    //public Transform PlayersBack;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
        controls.Newactionmap.Enable();
        //_animator = GetComponent<Animator>();
        controls.Newactionmap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Move.canceled += ctx => move = Vector2.zero;
    }

    /* private void OnEnable()
     {
         controls.Newactionmap.Enable();
     }
     private void OnDisable()
     {
         controls.Newactionmap.Disable();
     }*/
    private void FixedUpdate()
    {
        if (Jump)
        {
            if (isGrounded)
            {
                //_rb.AddForce(new Vector3(0f, _JumpForce, 0f), ForceMode.Impulse); //ForceMode.Impulse);
                _rb.AddForce(transform.up * _JumpForce);
                //Jump = false;

            }
        }
        //else { return; }
        //_rb.velocity = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        Vector3 Movement = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        Movement.y = _rb.velocity.y;
        _rb.velocity = Movement;
        transform.Rotate((transform.up * move.x) * rotationSpeed * Time.fixedDeltaTime);

        /*if (move != Vector3.zero)
        {
            transform.forward = move;
        }*/
        // _rb.AddForce(new Vector3(0f, 0f, move.y) * _speed * Time.fixedDeltaTime);;
        //move.Normalize();

    }
    private void Update()
    {
        //HandleRotation();
        //print(Time.timeScale);
        //print(_JumpForce);
        //print(_rb.velocity.y);        
        //_animator.SetFloat("Speed", _rb.velocity.magnitude);
        //_rb.AddForce(new Vector3(move.x, 0f, move.y) * _speed, ForceMode.Force);


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
        if (FreezeConstraints)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
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
            Physics.gravity = new Vector3(0f, -20f, 0);
            //Time.timeScale = 1f;
            //_rb.mass = originalMass;
            _JumpForce /= 2f;
            SlowTime = false;
            Nogravity = true;
        }
    }
}
