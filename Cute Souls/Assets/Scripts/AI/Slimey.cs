using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    private void Start()
    {
        m_currentBehaviour = archetype.m_behaviours[4];
    }
    void Update ()
    {
        m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.
    }
}
