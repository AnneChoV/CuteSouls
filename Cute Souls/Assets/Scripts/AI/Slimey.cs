using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    private void Start()
    {
        m_currentBehaviour = archetype.m_behaviours[0];
        archetype.m_abilities[1].UseAbility();
    }
    void Update ()
    {
        m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.
        archetype.m_abilities[0].UseAbility();
    }
}
