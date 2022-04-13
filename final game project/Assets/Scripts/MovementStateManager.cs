using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    private float speed;
    private float boostTimer;
    private bool boosting;


    public bool disabled = false;
    public float moveSpeed;
    public float runSpeed = 4, runBackSpeed = 3;
    public float bulletTimeSpeed = 3;
    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput;
    [HideInInspector] public float vInput;
    CharacterController controller;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    // Health
    

    //Movement States 
    MovementBaseState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunState Run = new RunState();
    [HideInInspector] public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        
        SwitchState (Idle);

        speed = 5;
        boostTimer = 0;
        boosting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        anim.SetFloat("hzInput",hzInput);
        anim.SetFloat("vInput",vInput);
        currentState.UpdateState(this);
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(!disabled)
        {

           GetDirectionAndMove();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlowMotion();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlowMotion();
        }
        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 3)
            {
                speed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Speed Boost")
        {
            boosting = true;
            speed = 15;
            Destroy(other.gameObject);
        }
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            dir = transform.forward * vInput + transform.right * hzInput * bulletTimeSpeed; 
        }
        else
        {
            dir = transform.forward * vInput + transform.right * hzInput; 
        }
        controller.Move(dir.normalized * speed * Time.deltaTime);
    }
    
    bool IsGround()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z );
        
        if(Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Gravity()
    {
        if(!IsGround())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y < 0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    }
    void StartSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(1,0.2f,5);
    }

    void StopSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(0.2f, 1,5);
    }
}
