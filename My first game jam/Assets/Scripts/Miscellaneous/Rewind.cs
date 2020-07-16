using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rewind : MonoBehaviour
{
    public bool Is_rewinding = false;


    private List<Vector3> positions;
 


    void Start()
    {
        positions = new List<Vector3>();
      
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
        positions.Insert(0,transform.position);
       
    }
    void _Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[positions.Count-1];
           // positions.RemoveAt(0);
           

        }
        else
        {
            positions = new List<Vector3>();
            StopRewind();

        }
    }

    void StartRewind()
    {
        Is_rewinding = true;

    }

    void StopRewind()
    {
        Is_rewinding = false;
    }
   
    

}