
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
 
   public CharacterController controller;
   public float speed = 6f;
   public float gravity = -9.81f;

   public float turnSmoothTime = 0.1f;

   float turnSmoothVelocity;

   Vector3 velocity;

   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;

   bool isGround;

    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGround == true && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        
        if(direction.magnitude>=0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle,0f);

            Vector3 moveDir = Quaternion.Euler (0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized*speed*Time.deltaTime);            
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }

}