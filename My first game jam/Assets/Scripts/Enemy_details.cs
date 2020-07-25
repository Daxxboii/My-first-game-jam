using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Specs")]
public class Enemy_details : Base
{
    public enum Type
    {
        meelee,shoot
    }
    public int health;
    public int hit_damage;
    public Type type;
    public float speed;
}
