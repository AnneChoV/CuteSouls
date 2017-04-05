using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashOne : Ability {

    public float timer;
    public bool dashing;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (dashing)
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }


        if (dashing && timer < 0)
        {
            if (movementManager.isfacingRight == true)
            {
                // Reset constraints after timer
                GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GetComponentInParent<Rigidbody2D>().velocity = new Vector2(characterStats.m_TotalStats.m_maxSpeed / 2, 0.0f);
            }

            else
            {
                // Reset constraints after timer
                GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GetComponentInParent<Rigidbody2D>().velocity = new Vector2(-characterStats.m_TotalStats.m_maxSpeed / 2, 0.0f);
            }

            dashing = false;
        }
    }

    public override void UseAbility()
    {
        if (!characterStats.isInAir)
        {
            dashing = true;

            timer = 0.1f;

            if (movementManager.isfacingRight == true)
            {
                GetComponentInParent<Rigidbody2D>().AddForce(Vector3.right * 70, ForceMode2D.Impulse);
            }
            else
            {
                GetComponentInParent<Rigidbody2D>().AddForce(Vector3.left * 70, ForceMode2D.Impulse);

            }
        }
    }
}
