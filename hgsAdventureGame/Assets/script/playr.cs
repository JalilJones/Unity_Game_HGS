using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playr : MonoBehaviour
{   
    // how to crate variable
    //Step1:public
    //step2:type of var
    //step 3: name the variable  
    // example: public string PlayerSpeech;

    [Header("Movement Vars")]
     public float moveSpeed;


    [Header("Jumping Vars")]
    public float yForce;

    public float yGravity;
    
    public float maxGravity;

    public float jumpSpeed;

    public bool isJumping;


    [Header ("Refrences")]
    public CharacterController myController;
    doublejump doubleJump; 
    public GameObject playerModel; 
    public Animator animator;

   

    // Start is called before the first frame update
    void Start()
    {
        //this is how to write a print statment
        doubleJump = GetComponent<doublejump>();
        myController = GetComponent<CharacterController>();
        isJumping = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
      {
          MoveRight();
      }
        //movesright

        if(Input.GetKey(KeyCode.A))
      {
          MoveLeft();
      }
        //movesleft

        if(Input.GetKey(KeyCode.W))
      {
          MoveForward();
      }
        //moveup
        if(Input.GetKey(KeyCode.S))
      {
          MoveBack();
      }

         if(Input.GetKeyDown(KeyCode.Space))
        {
          if(!isJumping)
          {
            Jump();
          }

          else
          {
            if(doubleJump.available)
            {
              Jump(); 
              doubleJump.available = false; 
              animator.SetTrigger("DoubleJump");
            }

          }
        
        }

        if(myController.isGrounded && yForce < 0)
        {
           
          doubleJump.available = true;
          animator.SetBool("IsJumping",false);
        }

        if(!myController.isGrounded)
        {
          yForce = Mathf.Max(maxGravity, yForce + (yGravity* Time.deltaTime)); 
        }
         

        //add yforce to player (up/down)
        myController.Move(Vector3.up * yForce * Time.deltaTime);
        if(IsIdle())
        {
           animator.SetFloat("Speed",0);

        }

    } 

    bool IsIdle()
    {
      if(!Input.GetKey(KeyCode.W) && 
        !Input.GetKey(KeyCode.A) && 
        !Input.GetKey(KeyCode.S) && 
        !Input.GetKey(KeyCode.D) && 
        !isJumping)
      {
          return true; 
      }
          return false; 
    }

    void MoveForward()
    {
        myController.Move(Vector3.forward*Time.deltaTime*moveSpeed);
         playerModel.transform.eulerAngles = new Vector3 (0,0,0);
         animator.SetFloat("Speed",1);
    }

    void MoveLeft()
    {
         myController.Move(Vector3.left*Time.deltaTime*moveSpeed);
          playerModel.transform.eulerAngles = new Vector3 (0,270,0);
          animator.SetFloat("Speed",1);
    }
    
    

     void MoveRight()
    {
        myController.Move(Vector3.right*Time.deltaTime*moveSpeed);
        playerModel.transform.eulerAngles = new Vector3 (0,90,0);
        animator.SetFloat("Speed",1);
    }

    void MoveBack()
    {
         myController.Move(Vector3.back*Time.deltaTime*moveSpeed);
          playerModel.transform.eulerAngles = new Vector3 (0,180,0);
          animator.SetFloat("Speed",1);
    }


       void Jump()
      {
        yForce = jumpSpeed;
        isJumping = true; 
        animator.SetBool("IsJumping",true);
      }
    
}   
 