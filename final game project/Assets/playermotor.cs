using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermotor : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = 5.0f;
    private float jumpForce = 20.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = - gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0,verticalVelocity,0);
        controller.Move(moveVector * Time.deltaTime);

    }
}
