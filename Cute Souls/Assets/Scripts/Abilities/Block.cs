using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Ability
{
    public override void UseAbility()
    {
        characterStats.m_currentProtoclass.timeUntilNextDamageTaken = 0.5f; //NEEED TESTING
    }

}
