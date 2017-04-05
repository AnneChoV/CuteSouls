using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOneAttempt : Ability
{
    public float currentBlockingDamagetimer;

    public override void UseAbility()
    {
        Debug.Log("Using BlockOne");
        if (currentBlockingDamagetimer <= 0.0f)
        {
            Debug.Log("Increasing blocking timer.");
           // currentBlockingDamagetimer = characterStats.m_currentProtoclass.blockingtimer;
        }
        else
        {
            Debug.Log("Already blocking");
        }
    }

    void Update()
    {
        if (currentBlockingDamagetimer > 0.0f)
        {
            if (movementManager.isfacingRight)
            {
                Debug.Log("Blocking Right");
                characterStats.isBlockingDamageFromRight = true;
            }
            else
            {
                Debug.Log("Blocking Left");
                characterStats.isBlockingDamageFromLeft = true;
            }
        }
        else
        {
            Debug.Log(currentBlockingDamagetimer);
            Debug.Log("Not Blocking");
            characterStats.isBlockingDamageFromRight = false;
            characterStats.isBlockingDamageFromLeft = false;
        }

        //if (characterStats.m_currentProtoclass.timeUntilNextBlock <= 0.0f)
        //{
        //    characterStats.m_currentProtoclass.timeUntilBlockRunsOut = characterStats.m_currentProtoclass.blockingtimer;
        //}
    }
}
