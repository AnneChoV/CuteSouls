using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    [ReadOnly] public Archetype archetype; //Use this to get the abilties list and the behaviour list.
    [ReadOnly] public MovementManager movementManager;

    [ReadOnly] public GameObject m_player;
    [ReadOnly] public Vector3 m_playerPosition;
    [ReadOnly] public float m_distanceFromPlayer;

    [ReadOnly] public BehaviourAbstract m_currentBehaviour;


    private void OnValidate()
    {
        archetype = GetComponent<Archetype>();  //This means every enemy that extends this class already has the archetype.
        movementManager = GetComponent<MovementManager>();
        m_player = GameObject.Find("Player");

        m_playerPosition = m_player.transform.position;
        m_distanceFromPlayer = GetDistanceFromTarget(m_playerPosition);
    }

    public float GetDistanceFromTarget(Vector3 _position)
    {
        return Vector3.Distance(transform.position, _position);
    }
}

