using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{

    public override void UseAbility()
    {
        GetComponentInParent<Rigidbody2D>().AddForce(Vector3.left * 10, ForceMode2D.Impulse);
    }
}