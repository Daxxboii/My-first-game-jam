using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rewind : MonoBehaviour
{
    public bool Is_rewinding;
    List<Vector3> positions;
    private bool cleanup;
    public float rewind_time = 2f;
    private int maintaining_factor;


    void Awake()
    {
        positions = new List<Vector3>();
        StartCoroutine(Cleanup());
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
     
            positions.Add(transform.position);
            //Debug.Log(cleanup);
            if (cleanup == true)
            {
                positions.RemoveAt(0);
            }

        
    }

    void _Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[positions.Count - 1];
            positions.RemoveAt(positions.Count - 1);
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
        cleanup = false;
        positions = new List<Vector3>();
        StartCoroutine(Cleanup());
    }
   
    IEnumerator Cleanup()
    {
        yield return new WaitForSeconds(rewind_time);
        maintaining_factor = positions.Count;
        cleanup = true;
    }
}
   

