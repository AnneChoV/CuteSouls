using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : Ability
{
    public override void UseAbility()
    {
        characterStats.isReducingDamage = true;
    }

    void Update()
    {
        Debug.Log("Is this being called? Needs testing");

        if (characterStats.m_currentProtoclass.timeUntilNextBlock <= 0.0f)
        {
            characterStats.m_currentProtoclass.timeUntilBlockRunsOut = characterStats.m_currentProtoclass.blockingTimer;
        }
    }
}
