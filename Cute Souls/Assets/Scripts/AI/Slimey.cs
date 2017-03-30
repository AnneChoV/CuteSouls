using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    public GameObject SlimeyProjectile;


    public float timeBetweenUseAbilityZero;
    [ReadOnly] private float abilityZeroTimer;


    private void Start()
    {
        m_currentBehaviour = archetype.m_behaviours[1];
      //  archetype.m_abilities[1].UseAbility();
    }
    public override void Update()
    {
        base.Update();
        m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.

        abilityZeroTimer -= Time.deltaTime;

        if (abilityZeroTimer <= 0.0f)
        {
            Debug.Log(m_playerPosition);
           // archetype.m_abilities[0].UseAbility(m_playerPosition, transform.position, SlimeyProjectile);
            abilityZeroTimer = timeBetweenUseAbilityZero;
        }
    }

    private void OnValidate()
    {
        abilityZeroTimer = timeBetweenUseAbilityZero;
    }
}
