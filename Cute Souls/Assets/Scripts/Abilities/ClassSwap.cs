using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSwap : Ability    //If we want to allow enemies to use this, we will need to create a class
{
    public override void UseAbility()
    {
        int numberOfArchetypesAvailable = characterStats.availableArchetypes.Length;
        int indexOfCurrent = System.Array.IndexOf(characterStats.availableArchetypes, characterStats.m_currentProtoclass);
        int indexOfNext = (indexOfCurrent + 1) % numberOfArchetypesAvailable;

        characterStats.m_currentProtoclass = characterStats.availableArchetypes[indexOfNext];
        GetComponentInParent<SpriteRenderer>().sprite = characterStats.m_Sprites[indexOfCurrent];
        GetComponentInParent<Animator>().runtimeAnimatorController = characterStats.m_currentProtoclass.animatorController;
    }
}
