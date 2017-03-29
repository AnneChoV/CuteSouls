﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourAbstract : MonoBehaviour
{
    public MovementManager m_movementManager;

    [ReadOnly] public GameObject m_player;
   [ReadOnly] public Vector3 m_playerPosition;

    private void OnValidate()
    {
        m_movementManager = GetComponentInParent<MovementManager>();

        m_player = GameObject.Find("Player");

    }
    public abstract void ActOnBehaviour(Vector3 _targetPosition);

    private void Update()
    {
        if (m_player != null)
        {
            m_playerPosition = m_player.transform.position; //if this is displaying an error that it cant find it, check if any of the enemies have a reference to the player as proof it's still working. Unity dumb.
        }
    }
}
