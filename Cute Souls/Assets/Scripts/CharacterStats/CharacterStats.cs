using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//THIS NEEDS TO BE CHANGED TO STATS MANAGER

public class CharacterStats : MonoBehaviour {   //This class is used by both player and enemy as a storage for their stats. Things like movement speed are here in case they change according to equipment or enemy boss phase etc.
    
    [Header("Character Stats")]

    public Archetype m_currentProtoclass;
    [ReadOnly] public float m_currentHealth;

    [ReadOnly]
    public StatsTemplate m_defaultStats;
    [ReadOnly]
    public StatsTemplate m_equipmentStats;
    [ReadOnly]
    public StatsTemplate m_TotalStats;



    [Header("Movement Status's")]
    [ReadOnly] public bool IsGrounded;
    [ReadOnly] public bool IsOnLeftWall;
    [ReadOnly] public bool IsOnRightWall;
    [ReadOnly] public bool isInAir;

    private void OnValidate()
    {
        m_defaultStats = m_currentProtoclass.m_classDefaultStats;
        m_equipmentStats = m_currentProtoclass.m_EquipmentStats;
        m_TotalStats = m_currentProtoclass.m_EquipmentStats;

        m_TotalStats.m_Acceleration = m_defaultStats.m_Acceleration + m_equipmentStats.m_Acceleration;
        m_TotalStats.m_airAcceleration = m_defaultStats.m_airAcceleration + m_equipmentStats.m_airAcceleration;
        m_TotalStats.m_AirFriction = m_defaultStats.m_AirFriction + m_equipmentStats.m_AirFriction;
        m_TotalStats.m_groundFriction = m_defaultStats.m_groundFriction + m_equipmentStats.m_groundFriction;
        m_TotalStats.m_Health = m_defaultStats.m_Health + m_equipmentStats.m_Health;
        m_TotalStats.m_jumpHeight = m_defaultStats.m_jumpHeight + m_equipmentStats.m_jumpHeight;
        m_TotalStats.m_jumpsTotal = m_defaultStats.m_jumpsTotal + m_equipmentStats.m_jumpsTotal;
        m_TotalStats.m_maxSpeed = m_defaultStats.m_maxSpeed + m_equipmentStats.m_maxSpeed;
    }
}
