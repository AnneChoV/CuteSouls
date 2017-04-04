using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Dash : Ability
//{
//    public override void UseAbility()
//    {
//        GetComponentInParent<Rigidbody2D>().AddForce(Vector3.left * 50, ForceMode2D.Impulse);
//        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
//    }

//    public override void UseAbility(float _damage)
//    {
//       //no damage.
//    }
//}

public class Dash : Ability
{
    public float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("Current timer: " + timer);

        if (timer > 0)
        {
            // Reset constraints after timer
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(characterStats.m_TotalStats.m_maxSpeed/2, 0.0f);
        }
    }

    public override void UseAbility()
    {
        timer = 0.4f;

        GetComponentInParent<Rigidbody2D>().AddForce(Vector3.right * 200, ForceMode2D.Impulse);

        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY |
            RigidbodyConstraints2D.FreezeRotation;


    }

    public override void UseAbility(float _damage)
    {

    }
}