using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//THIS NEEDS TO BE CHANGED TO STATS MANAGER

public class CharacterStats : MonoBehaviour {   //This class is used by both player and enemy as a storage for their stats. Things like movement speed are here in case they change according to equipment or enemy boss phase etc.
    
    [Header("Character Stats")]

    public Archetype m_currentProtoclass;
    [ReadOnly] public Archetype[] availableArchetypes;
    public Sprite[] m_Sprites;
    [ReadOnly] public float m_currentHealth;
    [ReadOnly] public float m_MaxHealth;
    [ReadOnly] public float m_percentageHealth; //USE THIS FOR THE BAR
    [ReadOnly] public int jumpsAvailable;

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

    [ReadOnly] public bool isReducingDamage;
    [ReadOnly] public bool isParrying;

    private void OnValidate()
    {
        m_TotalStats = m_currentProtoclass.m_totalStats;

        availableArchetypes = GetComponents<Archetype>();

        if (!IsOnLeftWall && !IsOnRightWall && !IsGrounded)
        {
            isInAir = true;
        }
        m_currentHealth = m_TotalStats.m_Health;
        m_MaxHealth = m_TotalStats.m_Health;
    }

    private void Update()
    {
        m_TotalStats = m_currentProtoclass.m_totalStats;    //THIS MIGHT CAUSE LAG.
    }

    public void UpdatePercentageHealth()
    {
        m_percentageHealth = m_currentHealth / m_MaxHealth * 100;
    }

    public void TakeDamage(float _damage, bool isRanged)
    {

        if (m_currentProtoclass.timeUntilNextDamageTaken <= 0.0f && !isParrying)
        {
            if (isReducingDamage)
            {
                _damage /= 2;
            }
            Debug.Log(transform.name + " took " + _damage + " damage.");
            m_currentHealth -= _damage;
            UpdatePercentageHealth();

            m_currentProtoclass.timeUntilNextDamageTaken = m_currentProtoclass.immunityFramesNumber;

            if (m_currentHealth <= 0.0f)
            {
                m_currentProtoclass.EnvokeDeath();
            }
        }

        else if (isParrying)
        {
            // if the parry is tier one and the attack is not a projectile
            if (!isRanged && GetComponent<Mouse>().m_currentClassSkillTier == 1)
            {
                Debug.Log("Taking damage?");
                m_currentHealth -= _damage;
                UpdatePercentageHealth();

                m_currentProtoclass.timeUntilNextDamageTaken = m_currentProtoclass.immunityFramesNumber;

                if (m_currentHealth <= 0.0f)
                {
                    m_currentProtoclass.EnvokeDeath();
                }

                isParrying = false;
            }

            isParrying = false;

            Debug.Log("No damage because I got dem parrying skills");
        }
    }
}
