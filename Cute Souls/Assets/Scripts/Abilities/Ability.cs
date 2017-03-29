using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {
    public CharacterStats characterStats;
    public string abilityName;
    private void OnValidate()
    {
        characterStats = GetComponentInParent<CharacterStats>();
    }
    public abstract void UseAbility();
}
