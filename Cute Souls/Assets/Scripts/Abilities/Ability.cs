using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {
    public CharacterStats characterStats;
    public string abilityName;
    public Vector3 target;
    private void OnValidate()
    {
        characterStats = GetComponentInParent<CharacterStats>();
    }
    public abstract void UseAbility();
}
