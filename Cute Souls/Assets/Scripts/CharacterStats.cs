using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {   //This class is used by both player and enemy as a storage for their stats. Things like movement speed are here in case they change according to equipment or enemy boss phase etc.
    
    [Header("Character Stats")]
    [ReadOnly] public float m_currentHealth;
    public Class currentClass;

    [Header("Movement Status's")]
    [ReadOnly] public bool IsGrounded = true;
    [ReadOnly] public bool IsOnLeftWall;
    [ReadOnly] public bool IsOnRightWall;
    [ReadOnly] public bool isInAir;


    //IF YOU NEED TO CHANGE THE SLIDER SETTINGS EDIT THE RANGE:
    [Header("Movement Variables")]

    [ReadOnly] public float m_maxSpeed;    //A limitor for speed, will not make things faster after they reach this speed.
    [ReadOnly] public float m_Acceleration;    //Affects how fast the object accelerates, has the side affect of affecting speed if it's too high (ill see if Austin has a better way to do this).
    [ReadOnly] public float m_airAcceleration; //Is a percentage of the normal acceleration.
    [ReadOnly] public float m_groundFriction;  //Only slows when the player is not pressing keys.
    [ReadOnly] public float m_AirFriction;     //Only slows when the player is not pressing keys and is in the air.
    [ReadOnly] public float m_jumpHeight;  //Changes the upwards impulse force on key press, is multiplied by jumpSpeed gravity.
    [ReadOnly] public float m_jumpSpeedGravityScale;   //Directly changes this entities gravity. Needs to be atleast one or you can't move.
    [ReadOnly] public int m_jumpsLeft;
    [ReadOnly] public float m_wallSlideSpeed;


    //Couldn't think of a better place to put this, even though it's shared. :(
    public enum Class
    {
        TORTOISE,
        MELEE,
        PORCUPINE,
        EVILSLASHER
    }

    private void OnValidate()
    {
        InitiateStats();
   
    }

    public void InitiateStats()
    {
        switch(currentClass)
        {
            case Class.TORTOISE:
                GetComponentInChildren<Tortoise>().InitiateStats();
                Debug.Log("Turtle activate");
                break;
            case Class.PORCUPINE:
                GetComponentInChildren<Porcupine>().InitiateStats();
                Debug.Log("PORK actived");
                break;
            case Class.MELEE:
                GetComponentInChildren<Melee>().InitiateStats();
                Debug.Log("mealee activated");
                break;
            case Class.EVILSLASHER:
                break;
            default:
                break;

        }
    }
}
