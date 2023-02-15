using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController controller;

    public float speed = 20f;
    public float gravity = -100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f; //Radius of sphere used to check if player is touching the ground
    public LayerMask groundMask; //Control what object the sphere will check for

    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    bool doubleJump;
    

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //If collides with anything in groundMask, isGround will be = True

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // makes sure to force player down on the ground
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z; //Arrow that points in direction you want to move

        controller.Move(move * speed * Time.deltaTime); //deltaTime is added so it will not be frame rate dependant 



        //Sprinting
         if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 30f;
        }
        else{
            speed = 20f;
        }
        



//TODO Make momentum smoother
//UNFINISHED BELOW

         if(Input.GetKey(KeyCode.LeftShift) && Input.GetButtonDown("Jump") && isGrounded) 
        {
            Debug.Log("Jump while sprinting");
            speed = 1000f;

        }
        

        if(Input.GetButtonDown("Jump") && isGrounded) //Checks if SPACE is pressed and if the player is touching the ground  - Jump automatically maps to the SPACE key 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -20f * gravity);
            doubleJump = true; //Set to true to reset double jump ability
        }
        
        //Double jump
        //Check if player is in the air pressing jump
        else if(Input.GetButtonDown("Jump") && isGrounded == false && doubleJump == true){ //Checks if space is being pressed, while not touching ground and that doubleJump is true
             //Debug.Log("Mid air jump");        //Test
             //Debug.Log(doubleJump);            //Log to see if bool is true or false
             velocity.y = Mathf.Sqrt(jumpHeight * -25f * gravity);
             doubleJump = false; //Set doubleJump to false (This means you can't press space infinitely and fly)
             velocity.y += gravity * Time.deltaTime * 200f ;

        }


        velocity.y += gravity * Time.deltaTime * 5f ; //Gravity force

        controller.Move(velocity * Time.deltaTime);







    }
}
