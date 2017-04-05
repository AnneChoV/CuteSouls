using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {

    public CharacterStats characterStats;
    public MovementManager movementManager;
    //public string abilityName;

    private void OnValidate()
    {
        characterStats = GetComponentInParent<CharacterStats>();
        movementManager = GetComponentInParent<MovementManager>();
    }
    public abstract void UseAbility();  //Abstract forces all abilities to have a UseAbility function.
    public virtual void UseAbility(Vector3 _targetPosition) { }
    public virtual void UseAbility(Vector3 _targetPosition, Vector3 _instantiationPosition, GameObject _instantiationObject) { }
    public virtual void UseAbility(float _damage) { }

    public virtual void UseAbility(float _damage, float _range) { }


    //public bool CheckIfPlayerNearby()
    //{
    //    if ()
    //    return true;
    //}
}
