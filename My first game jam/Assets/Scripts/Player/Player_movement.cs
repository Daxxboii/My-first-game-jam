using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
   public Player_details move_details;
   
   public bool Is_Grounded;
   public LayerMask ground;
   public Transform Ground_Checker;
   public float Ground_Distance;
   public float gravity;
   
   private CharacterController controller;
    private CharacterController Crouch;

   private Vector3 pos;
   private float lockpos;
   
   //(0,0,0)
   private Vector3 move = Vector3.zero;

   void Awake(){
   	controller = this.gameObject.transform.GetComponent<CharacterController>();
   	 pos = transform.position;
   	 lockpos = pos.z;
   }

    private void Start()
    {
        Crouch = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate(){
     
     //Ground Check
      Is_Grounded = Physics.CheckSphere(Ground_Checker.position,Ground_Distance,ground);
    
    //Lock
    pos = transform.position;
    pos.z = lockpos;
    transform.position = pos;

      //Down Forcw
      if(Is_Grounded  && move.y<0){
        move.y = move_details.Down_force;
      }
      

      //Movement
      float MoveX = Input.GetAxis("Horizontal");
      move.x = MoveX * move_details.speed;


      //Jump
      if(Is_Grounded && Input.GetButton("Jump")){
        move.y = Mathf.Sqrt(move_details.Jump_force * move_details.Down_force * gravity);
        //Debug.Log("JUMP");
      }

        //Crouch
        if (Input.GetKey("c") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Crouch.height = move_details.Crouch_height;
        }
        else
        {
            Crouch.height = 2f;
        }

        //Fake Gravity
        move.y += gravity*Time.deltaTime;



       controller.Move(move);

        
    }

}