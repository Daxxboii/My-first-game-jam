using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
   public Player_details move_details;
   
   public bool Is_Grounded;
   public LayerMask ground;
   public Transform Ground_Checker;
   public float Ground_Distance;
   
   private CharacterController controller;
   
   private Vector3 move = Vector3.zero;

   void Awake(){
   	controller = this.gameObject.transform.GetComponent<CharacterController>();
   }

   void FixedUpdate(){
      Is_Grounded = Physics.CheckSphere(Ground_Checker.position,Ground_Distance,ground);
      
      if(Is_Grounded && move.y<0){
        move.y = move_details.gravity;
      }



       controller.Move(move);
  }
}