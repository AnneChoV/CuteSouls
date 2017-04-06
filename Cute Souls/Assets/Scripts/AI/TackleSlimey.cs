using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleSlimey : AbstractEnemy
{

    public GameObject SlimeyProjectile;

    public CircleCollider2D circle;

    public float timeBetweenUseAbilityZero;
    [ReadOnly]
    public float abilityZerotimer = 0.5f;

    private void Start()
    {
        //archetype.m_abilities[0].UseAbility(m_playerPosition, transform.position, SlimeyProjectile);
    }


    public override void Update()
    {
       base.Update();
       m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.

        abilityZerotimer -= Time.deltaTime;

    }

    public override void OnValidate()
    {

        base.OnValidate();

        abilityZerotimer = timeBetweenUseAbilityZero;
        circle = GetComponent<CircleCollider2D>();
        m_currentBehaviour = archetype.m_behaviours[1];


    }
}
