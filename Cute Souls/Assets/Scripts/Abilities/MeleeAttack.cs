﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Ability
{
    private float playerRange = 2.0f;
    private bool playerInRange;
    public LayerMask playerLayer;

    private Vector2 facingDirection;

    float damage = 0;
    float range = 0;

    public override void UseAbility()
    {
        Debug.Log("meleeing");
        if (movementManager.isfacingRight)
        {
            facingDirection = new Vector2(1, 0);
        }
        else
        {
            facingDirection = new Vector2(-1, 0);
        }

        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.parent.transform.position, facingDirection, range);
        for (int x = 0; x < hits.Length; x++)
        {
            CharacterStats currentTargetStats = hits[x].transform.GetComponent<CharacterStats>();
            if (currentTargetStats)
            {
                if (currentTargetStats.tag == tag)  //Shouldnt it be !=? Why is this working??? Oh well.
                {
                    currentTargetStats.TakeDamage(damage, false);
                }
            }

            if (hits[x].transform.tag.Equals("DestructableWall"))
            {
                hits[x].transform.gameObject.SetActive(false);
            }
        }
    }

    public override void UseAbility(float _damage, float _range)
    {
        Debug.Log("happening");
        damage = _damage;
        range = _range;
        UseAbility();
    }

}
