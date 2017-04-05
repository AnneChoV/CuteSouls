using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : Ability
{
    public bool isBlocking;

    public override void UseAbility()
    {
        characterStats.isBlocking = true;
        isBlocking = true;
    }

    void Update()
    {        
      
    }
}
