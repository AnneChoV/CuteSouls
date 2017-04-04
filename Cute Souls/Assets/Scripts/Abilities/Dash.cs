using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    public float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Current timer: " + timer);
    }

    public override void UseAbility()
    {
        timer = 0;

        GetComponentInParent<Rigidbody2D>().AddForce(Vector3.left * 10, ForceMode2D.Impulse);

        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | 
            RigidbodyConstraints2D.FreezeRotation;

        if (timer > 2)
        {
            // Reset constraints after timer
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(characterStats.m_TotalStats.m_maxSpeed, 0.0f);
        }
    }

    public override void UseAbility(float _damage)
    {

    }
}