using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : Ability
{
    [ReadOnly] public Vector3 m_targetPosition;
    [ReadOnly] public Vector3 m_instantiationPosition;
    [ReadOnly] public GameObject m_instantiationObject;

    public override void UseAbility()
    {
        GameObject createdProjectile;
        createdProjectile = Instantiate(m_instantiationObject, m_instantiationPosition, Quaternion.identity);
        createdProjectile.transform.LookAt(m_targetPosition);
        Debug.Log("If the object isn't showing up, turn off above line first.");
    }

    public override void UseAbility(Vector3 _targetPosition, Vector3 _instantiationPosition, GameObject _instantiationObject)
    {
        m_targetPosition = _targetPosition;
        m_instantiationPosition = _instantiationPosition;
        m_instantiationObject = _instantiationObject;
    }

}
