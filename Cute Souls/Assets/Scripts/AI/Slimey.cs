using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    public GameObject SlimeyProjectile;

    public CircleCollider2D circle;

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
        circle = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerStay2D(Collider2D collision) //lose health
    {
        if (collision.gameObject.name == "Player")
        {
            collision.GetComponent<CharacterStats>().m_currentHealth -= archetype.m_totalStats.m_DamageToOtherUponCollision;
            Debug.Log("Character lost health.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
        }
    }
}
