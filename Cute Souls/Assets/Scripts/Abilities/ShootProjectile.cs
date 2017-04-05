using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : Ability
{
    [ReadOnly] public Vector3 m_targetPosition;
    [ReadOnly] public Vector3 m_instantiationPosition;
    public GameObject m_instantiationObject;

    public override void UseAbility()
    {
        GameObject createdProjectile;
        createdProjectile = Instantiate(m_instantiationObject, m_instantiationPosition, Quaternion.identity, transform);
        createdProjectile.GetComponent<EnemyProjectile>().targetPosition = m_targetPosition;
    }

    public override void UseAbility(Vector3 _targetPosition, Vector3 _instantiationPosition, GameObject _instantiationObject)
    {
        m_targetPosition = _targetPosition;
        m_instantiationPosition = _instantiationPosition;  
        m_instantiationObject = _instantiationObject;

        if (_targetPosition.x > m_instantiationPosition.x)
        {
            m_instantiationPosition.x += 2.0f;
        }
        else
        {
            m_instantiationPosition.x -= 2.0f;
        }
        UseAbility();
    }

}
