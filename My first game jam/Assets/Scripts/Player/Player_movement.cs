using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
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

    public GameObject Manager_GameObject;
    public Manager_script manager;

    private CharacterController controller;
    private CharacterController Crouch;

    private Vector3 pos;
    private float lockpos;

    private float _speed;

    //position lock
    private Vector3 current_pos;
    private float pos_lock_z;
    //(0,0,0)
    private Vector3 move = Vector3.zero;

    void Awake()
    {
        controller = this.gameObject.transform.GetComponent<CharacterController>();
        pos = transform.position;
        lockpos = pos.z;
        Manager_GameObject = GameObject.FindWithTag("Manager");
        manager = Manager_GameObject.transform.GetComponent<Manager_script>();
        _speed = move_details.speed;
        pos_lock_z = transform.position.z;
    }

    private void Start()
    {
        Crouch = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        //Ground Check
        Is_Grounded = Physics.CheckSphere(Ground_Checker.position, Ground_Distance, ground);

        //Lock
        //  pos = transform.position;
        //  pos.z = lockpos;
        //   transform.position = pos;

        //lock 2

        current_pos = transform.position;
        current_pos.Set(transform.position.x, transform.position.y, pos_lock_z);
        transform.position = current_pos;
        
        //Down Forcw
        if (Is_Grounded && move.y < 0)
        {
            move.y = move_details.Down_force;
        }


        //Movement
        float MoveX = Input.GetAxis("Horizontal");
        move.x = MoveX * move_details.speed;


        //Jump
        if (Is_Grounded && Input.GetButton("Jump") || Is_Grounded && Input.GetKey(KeyCode.UpArrow))
        {
            move.y = Mathf.Sqrt(move_details.Jump_force * move_details.Down_force * gravity);
            //Debug.Log("JUMP");
        }

        //Crouch
        if (Input.GetKey("c") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.DownArrow))
        {
            Crouch.height = move_details.Crouch_height;
            move_details.speed = 0.2f;
        }
        else
        {
            Crouch.height = 2f;
            move_details.speed = _speed;
        }

      


        //Fake Gravity
        move.y += gravity * Time.deltaTime;



        controller.Move(move);


    }

}