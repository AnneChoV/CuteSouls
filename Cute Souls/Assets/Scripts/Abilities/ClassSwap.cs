using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSwap : Ability    //If we want to allow enemies to use this, we will need to create a class
{
    Rigidbody2D m_rigidBody;

    private int oldMaxJumps;
    public override void UseAbility()
    {
        oldMaxJumps = characterStats.m_TotalStats.m_jumpsTotal;
        SwitchToNextClass();
        ResetStats();
        UpdateVelocity();
    }

    private void Update()
    {
        characterStats.UpdatePercentageHealth();
    }

    public override void OnValidate()
    {
        base.OnValidate();
        m_rigidBody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void UpdateVelocity()
    {
        //VELOCITY RESET TO MAX
        if (Mathf.Abs(m_rigidBody.velocity.x) > characterStats.m_currentProtoclass.m_totalStats.m_maxSpeed)
        {
            if (m_rigidBody.velocity.x > 0.0f)
            {
                m_rigidBody.velocity = new Vector3(characterStats.m_currentProtoclass.m_totalStats.m_maxSpeed, m_rigidBody.velocity.y);
            }
            else
            {
                m_rigidBody.velocity = new Vector3(-characterStats.m_currentProtoclass.m_totalStats.m_maxSpeed, m_rigidBody.velocity.y);
            }
        }
    }

    private void ResetStats()
    {
        //RESET VALUES FOR STATS
        characterStats.m_defaultStats = characterStats.m_currentProtoclass.m_classDefaultStats;
        characterStats.m_equipmentStats = characterStats.m_currentProtoclass.m_EquipmentStats;

        characterStats.m_currentHealth = characterStats.m_MaxHealth * characterStats.m_percentageHealth / 100;

        characterStats.m_TotalStats = characterStats.m_currentProtoclass.m_totalStats;

        int offset = oldMaxJumps - characterStats.m_TotalStats.m_jumpsTotal;
        characterStats.jumpsAvailable -= offset;
    }

    private void SwitchToNextClass()
    {
        //FINDING NEXT CLASS
        int numberOfArchetypesAvailable = characterStats.availableArchetypes.Length;
        int indexOfCurrent = System.Array.IndexOf(characterStats.availableArchetypes, characterStats.m_currentProtoclass);
        int indexOfNext = (indexOfCurrent + 1) % numberOfArchetypesAvailable;
        characterStats.m_currentProtoclass = characterStats.availableArchetypes[indexOfNext];

        movementManager.spriteRenderer.sprite = characterStats.m_Sprites[indexOfCurrent];
        movementManager.m_animator.runtimeAnimatorController = characterStats.m_currentProtoclass.animatorController;
    }
}
