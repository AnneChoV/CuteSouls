using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : Ability
{
    public float currentReducingDamagetimer;

    public override void UseAbility()
    {
        characterStats.isReducingDamage = true;
        currentReducingDamagetimer = characterStats.m_currentProtoclass.timeUntilBlockRunsOut;
    }

    void Update()
    {        
        if (currentReducingDamagetimer <= 0.0f)
        {
            characterStats.isReducingDamage = false;
        }

        if (characterStats.m_currentProtoclass.timeUntilNextBlock <= 0.0f)
        {
            characterStats.m_currentProtoclass.timeUntilBlockRunsOut = characterStats.m_currentProtoclass.blockingtimer;
        }
    }
}
