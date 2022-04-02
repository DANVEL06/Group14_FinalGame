using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public bool disabled = false;
    public float moveSpeed;
    [HideInInspector] public Vector3 dir;
    float hzInput;
    float vInput;
    CharacterController controller;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    public int MaxHealth = 3;
    public int currentHealth;
    public UIHealthBar healthBar;
    public DestroyBullet damage;
    
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(!disabled)
        {
           // UpdateMouseLook();
            //UpdateMovement();
           GetDirectionAndMove();
            //InteractCheck();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);

            healthBar.SetHealth(currentHealth);
        }



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

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        dir = transform.forward * vInput + transform.right * hzInput; 
        controller.Move(dir * moveSpeed * Time.deltaTime);
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

    //public override bool Equals(object obj)
   // {
       // return obj is MovementStateManager manager &&
               //EqualityComparer<HealthBar>.Default.Equals(healthBar, manager.healthBar);
    //}
}
