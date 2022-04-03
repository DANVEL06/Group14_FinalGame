using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public bool disabled = false;
    public float moveSpeed;
    public float runSpeed = 4, runBackSpeed = 3;
    public float bulletTimeSpeed = 2;
    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput;
    [HideInInspector] public float vInput;
    CharacterController controller;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
<<<<<<< HEAD:final game project/Assets/Scripts/PlayerScripts/MovementStates/MovementStateManager.cs

    // Health
    public int maxHealth = 3;
    public int health { get { return currentHealth; }}
    int currentHealth;
=======
    public int MaxHealth = 3;
    public int currentHealth;
    public UIHealthBar healthBar;
    public DestroyBullet damage;
    
    
>>>>>>> 512aa920f35c4c0d3cb683acd1dad410223da00f:final game project/Assets/Scripts/MovementStateManager.cs

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
<<<<<<< HEAD:final game project/Assets/Scripts/PlayerScripts/MovementStates/MovementStateManager.cs
        currentHealth = maxHealth;
        SwitchState (Idle);
=======
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
>>>>>>> 512aa920f35c4c0d3cb683acd1dad410223da00f:final game project/Assets/Scripts/MovementStateManager.cs
        
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
<<<<<<< HEAD:final game project/Assets/Scripts/PlayerScripts/MovementStates/MovementStateManager.cs
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlowMotion();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlowMotion();
        }
=======
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);

            healthBar.SetHealth(currentHealth);
        }

>>>>>>> 512aa920f35c4c0d3cb683acd1dad410223da00f:final game project/Assets/Scripts/MovementStateManager.cs


    }
     void OnCollisionEnter(Collision collision)
     {
        if (collision.gameObject.tag == "Bullet")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
     }
   
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
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
<<<<<<< HEAD:final game project/Assets/Scripts/PlayerScripts/MovementStates/MovementStateManager.cs
    void StartSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(1,0.2f,5);
    }

    void StopSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(0.2f, 1,5);
    }
=======

    //public override bool Equals(object obj)
   // {
       // return obj is MovementStateManager manager &&
               //EqualityComparer<HealthBar>.Default.Equals(healthBar, manager.healthBar);
    //}
>>>>>>> 512aa920f35c4c0d3cb683acd1dad410223da00f:final game project/Assets/Scripts/MovementStateManager.cs
}
