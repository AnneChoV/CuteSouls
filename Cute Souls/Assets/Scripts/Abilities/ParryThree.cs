using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tier 3 Parry increases parry window
public class ParryThree : Ability
{
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
        parryWindow = -1.1f; // 1 second parry

        characterStats.isParrying = true;
        isParrying = true;
    }
}
