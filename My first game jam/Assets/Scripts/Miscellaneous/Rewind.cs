using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rewind : MonoBehaviour
{
    public bool Is_rewinding = false;
    public int Frames_to_go_back;
    public Animator anim;

    private List<Vector3> positions;
    



    void Start()
    {
        positions = new List<Vector3>(5);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }



    }

    void FixedUpdate()
    {
        if (Is_rewinding)
        {
            _Rewind();
        }
        else
        {
            Record();
        }
    }



    void Record()
    {
        if (positions.Count < Frames_to_go_back)
        {
            positions.Insert(0, transform.position);
        }
        else
        {

            positions.RemoveAt(positions.Count - 1);
        }
    }
    void _Rewind()
    {
        if (positions.Count > 0)
        {
            //these are for snappy transition
            //  transform.position = positions[positions.Count-1];

            //these are for smooth transition
            transform.position = positions[0];
            positions.RemoveAt(0);
          



        }
        else
        {
            positions = new List<Vector3>();
            StopRewind();
           

        }
    }

    void StartRewind()
    {
        //positions = new List<Vector3>();
        Is_rewinding = true;
        anim.SetBool("Reverse", true);

    }

    void StopRewind()
    {
        Is_rewinding = false;
        anim.SetBool("Reverse", false);
    }



}