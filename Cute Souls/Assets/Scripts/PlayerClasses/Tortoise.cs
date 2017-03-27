using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour
{

    [ReadOnly]
    public CharacterStats characterStats;
    //IF YOU NEED TO CHANGE THE SLIDER SETTINGS EDIT THE RANGE:
    [Header("Movement Variables")]
    [Range(0.0f, 50.0f)]
    public float m_maxSpeed;    //A limitor for speed, will not make things faster after they reach this speed.
    [Range(0.0f, 100.0f)]
    public float m_Acceleration;    //Affects how fast the object accelerates, has the side affect of affecting speed if it's too high (ill see if Austin has a better way to do this).
    [Range(0.0f, 100.0f)]
    public float m_airAcceleration; //Is a percentage of the normal acceleration.
    [Range(0.0f, 100.0f)]
    public float m_groundFriction;  //Only slows when the player is not pressing keys.
    [Range(0.0f, 100.0f)]
    public float m_AirFriction;     //Only slows when the player is not pressing keys and is in the air.
    [Range(0.0f, 50.0f)]
    public float m_jumpHeight;  //Changes the upwards impulse force on key press, is multiplied by jumpSpeed gravity.
    [Range(0.0f, 16.0f)]
    public float m_jumpSpeedGravityScale;   //Directly changes this entities gravity. Needs to be atleast one or you can't move.
    [Range(0, 100)]
    public int m_jumpsLeft;



    private void OnValidate()
    {
        characterStats = GetComponentInParent<CharacterStats>();
    }
    public void InitiateStats()
    {
        characterStats.m_maxSpeed = m_maxSpeed;
        characterStats.m_Acceleration = m_Acceleration;
        characterStats.m_airAcceleration = m_airAcceleration;
        characterStats.m_groundFriction = m_groundFriction;
        characterStats.m_AirFriction = m_AirFriction;
        characterStats.m_jumpHeight = m_jumpHeight;
        characterStats.m_jumpSpeedGravityScale = m_jumpSpeedGravityScale;
        characterStats.m_jumpsLeft = m_jumpsLeft;   //This one is gonna fuck shit up.
    }
}
