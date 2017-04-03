using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Ability
{
    private float playerRange = 2.0f;
    private bool playerInRange;
    public LayerMask playerLayer;

    float damage = 0;

    public override void UseAbility()
    {
        playerInRange = Physics2D.OverlapCircle(transform.parent.position, playerRange, playerLayer);
        if (playerInRange)
        {
            //playerInRange.TakeDamage(damage);
            Debug.Log("Enemy hit the player!");
        }
    }

}
