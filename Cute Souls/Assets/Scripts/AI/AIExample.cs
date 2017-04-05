using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIExample : AbstractEnemy {

    public float timeBetweenUseAbilityZero;

    private float abilityZerotimer;

    private void OnValidate()
    {
        abilityZerotimer = timeBetweenUseAbilityZero;
    }

    //NOTE: THIS ENEMY DOESNT DO SHIT CAUSE IT HAS NO ABILITIES. PUT SOME ABILTIES IN ARCHETYPE.
    void Update () {
        abilityZerotimer -= Time.deltaTime;
        
        if (abilityZerotimer <= 0.0f)
        {
            archetype.m_abilities[0].UseAbility();  //Uses the ability in the 0 position, no matter what ability it is.
        }      
	}
}
