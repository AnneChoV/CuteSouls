using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTwo : Ability
{
    public override void UseAbility()
    {
        characterStats.m_currentProtoclass.timeUntilNextDamageTaken = characterStats.m_currentProtoclass.blockingtimer; //NEEED TESTING
    }
}
