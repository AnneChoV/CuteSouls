using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockThree : Ability
{

    public override void UseAbility()   //WILL HAVE TO DO A CHECK FOR RELEASE TO DISABLE THIS.
    {
        characterStats.m_currentProtoclass.timeUntilNextDamageTaken = characterStats.m_currentProtoclass.blockingtimer * 2; //NEEED TESTING
    }
}
