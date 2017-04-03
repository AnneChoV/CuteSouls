using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StatsTemplate {

    [Header("Character Stats")]
    public float m_Health;
    public float m_DamageToOtherUponCollision;
    public float m_damageMultiplier;

    //IF YOU NEED TO CHANGE THE SLIDER SETTINGS EDIT THE RANGE:
    [Header("Movement Variables")]
    [Range(0.0f, 50.0f)]
    public float m_maxSpeed;    //A limitor for speed, will not make things faster after they reach this speed.
    [Range(0.0f, 100.0f)]
    public float m_Acceleration;    //Affects how fast the object accelerates, has the side affect of affecting speed if it's too high (ill see if Austin has a better way to do this).
    [Range(0.0f, 100.0f)]
    public float m_airAcceleration; //Is a percentage of the normal acceleration.
    [Range(0.0f, 150.0f)]
    public float m_groundFriction;  //Only slows when the player is not pressing keys.
    [Range(0.0f, 100.0f)]
    public float m_AirFriction;     //Only slows when the player is not pressing keys and is in the air.
    [Range(0.0f, 50.0f)]
    public float m_jumpHeight;  //Changes the upwards impulse force on key press, is multiplied by jumpSpeed gravity.
    [Range(0.0f, 16.0f)]
    public float m_jumpSpeedGravityScale;   //Directly changes this entities gravity. Needs to be atleast one or you can't move.
    [Range(0, 100)]
    public int m_jumpsTotal;

    public StatsTemplate Add(StatsTemplate _AddedTemplate)
    {
        StatsTemplate totalStats = new StatsTemplate();
        totalStats.m_Health = m_Health + _AddedTemplate.m_Health;
        totalStats.m_DamageToOtherUponCollision = m_DamageToOtherUponCollision + _AddedTemplate.m_DamageToOtherUponCollision;
        totalStats.m_damageMultiplier = m_damageMultiplier + _AddedTemplate.m_damageMultiplier;

        totalStats.m_maxSpeed = m_maxSpeed + _AddedTemplate.m_maxSpeed;
        totalStats.m_Acceleration = m_Acceleration + _AddedTemplate.m_Acceleration;
        totalStats.m_airAcceleration = m_airAcceleration + _AddedTemplate.m_airAcceleration;
        totalStats.m_groundFriction = m_groundFriction + _AddedTemplate.m_groundFriction;
        totalStats.m_AirFriction = m_AirFriction + _AddedTemplate.m_AirFriction;
        totalStats.m_jumpHeight = m_jumpHeight + _AddedTemplate.m_jumpHeight;
        totalStats.m_jumpSpeedGravityScale = m_jumpSpeedGravityScale + _AddedTemplate.m_jumpSpeedGravityScale;
        totalStats.m_jumpsTotal = m_jumpsTotal + _AddedTemplate.m_jumpsTotal;

        return totalStats;
    }
}
