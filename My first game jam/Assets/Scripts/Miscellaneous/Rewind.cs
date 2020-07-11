using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public bool Is_rewinding;
    List<Vector3> positions;


    void Awake()
    {
        positions = new List<Vector3>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Start_rewind();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            Stop_rewind();
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
        positions.Insert(0, transform.position);
        //Debug.Log(positions[0]);
    }

    void _Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            Stop_rewind();
        }
    }
    void Start_rewind()
    {
        Is_rewinding = true;
    }



    void Stop_rewind()
    {
        Is_rewinding = false;
    }
}
   

