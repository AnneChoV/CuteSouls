using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    public GameObject SlimeyProjectile;

    public CircleCollider2D circle;

    public float timeBetweenUseAbilityZero;
    [ReadOnly] private float abilityZerotimer;

    private void Start()
    {
        m_currentBehaviour = archetype.m_behaviours[1];
        archetype.m_abilities[0].UseAbility(m_playerPosition, transform.position, SlimeyProjectile);

    }
    public override void Update()
    {
        base.Update();
        m_currentBehaviour.ActOnBehaviour(m_playerPosition);    //This should make it move how we want.

        abilityZerotimer -= Time.deltaTime;

        if (abilityZerotimer <= 0.0f)
        {
          //  Debug.Log(m_playerPosition);
            archetype.m_abilities[0].UseAbility(Camera.main.transform.parent.position, transform.position, SlimeyProjectile);
            abilityZerotimer = timeBetweenUseAbilityZero;
            //Debug.Log(Camera.main.transform.parent.position);
        }
    }

    private void OnValidate()
    {
        abilityZerotimer = timeBetweenUseAbilityZero;
        circle = GetComponent<CircleCollider2D>();
    }
}
