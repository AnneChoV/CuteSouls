using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    [ReadOnly] public Archetype archetype;
    [ReadOnly] public MovementManager movementManager;

    private void OnValidate()
    {
        archetype = GetComponent<Archetype>();  //This means every enemy that extends this class already has the archetype.
        movementManager = GetComponent<MovementManager>();
    }
}

