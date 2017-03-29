using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    [ReadOnly] public Archetype archetype;
    [ReadOnly] public MovementManager movementManager;

    [ReadOnly] public GameObject player; 
    [ReadOnly] public Vector3 playerPosition;
    [ReadOnly] public float distanceFromPlayer;


    private void OnValidate()
    {
        archetype = GetComponent<Archetype>();  //This means every enemy that extends this class already has the archetype.
        movementManager = GetComponent<MovementManager>();
        player = GameObject.Find("Player");

        playerPosition = player.transform.position;
        distanceFromPlayer = GetDistanceFromTarget(playerPosition);
    }

    public float GetDistanceFromTarget(Vector3 _position)
    {
        return Vector3.Distance(transform.position, _position);
    }
}

