using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Specs")]
public class Player_details :Base
{
    public float speed;
    public float Down_force;
    public float Jump_force;
    public float Crouch_height;
    public int health;
    internal bool position;
   
    
}
