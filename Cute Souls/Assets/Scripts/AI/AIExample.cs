using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIExample : AbstractEnemy {

    public float timeBetweenUseAbilityZero;

    private float abilityZeroTimer;

    private void OnValidate()
    {
        abilityZeroTimer = timeBetweenUseAbilityZero;
    }

    //NOTE: THIS ENEMY DOESNT DO SHIT CAUSE IT HAS NO ABILITIES. PUT SOME ABILTIES IN ARCHETYPE.
    void Update () {
        abilityZeroTimer -= Time.deltaTime;
        
        if (abilityZeroTimer <= 0.0f)
        {
            archetype.m_abilities[0].UseAbility();  //Uses the ability in the 0 position, no matter what ability it is.
        }      
	}
}
