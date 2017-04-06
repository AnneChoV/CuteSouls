﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingSlimey : AbstractEnemy
{

    //if we can make it block its back or something interesting. Maybe shoot at player

    public GameObject SlimeyProjectile;

    public CircleCollider2D circle;

    public float timeBetweenUseAbilityZero;
    [ReadOnly]
    public float abilityZerotimer = 0.5f;

    private void Start()
    {
        GetComponent<CharacterStats>().IsGrounded = true;
        //archetype.m_abilities[0].UseAbility(m_playerPosition, transform.position, SlimeyProjectile);
    }


    public override void Update()
    {
        
        base.Update();
        m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.

        abilityZerotimer -= Time.deltaTime;

        if (abilityZerotimer <= 0.0f)
        {
            //To make it hit player:
            //archetype.m_abilities[0].UseAbility(Camera.main.transform.parent.position, transform.position, SlimeyProjectile);

            // archetype.m_abilities[0].UseAbility(new Vector2(transform.position.x - 10, transform.position.y), transform.position, SlimeyProjectile);
            //  abilityZerotimer = timeBetweenUseAbilityZero;
            //Debug.Log(Camera.main.transform.parent.position);
        }
    }

    public override void OnValidate()
    {
        base.OnValidate();
        abilityZerotimer = timeBetweenUseAbilityZero;
        circle = GetComponent<CircleCollider2D>();
        m_currentBehaviour = archetype.m_behaviours[1];


    }
}