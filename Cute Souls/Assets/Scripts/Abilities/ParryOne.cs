using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tier 1 Parry only parries projectiles
public class ParryOne : Ability {

    public float parryWindow;
    public bool isParrying;

    private void Start()
    {
        isParrying = characterStats.isParrying;
    }

    private void Update()
    {
        parryWindow += Time.deltaTime;

        if (isParrying && parryWindow > 0)
        {
            characterStats.isParrying = false;
            isParrying = false;
        }
    }
    public override void UseAbility()
    {
        parryWindow = -0.6f; // 0.5 second parry

        characterStats.isParrying = true;
        isParrying = true;
    }
}
