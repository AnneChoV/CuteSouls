using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAround : BehaviourAbstract
{
    public float moveSpeed;
    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;

    public override void ActOnBehaviour(Vector3 _targetPosition)
    {
        playerInRange = Physics2D.OverlapCircle(transform.parent.position, playerRange, playerLayer);
        if (playerInRange)
        {
            transform.parent.GetComponent<Rigidbody2D>().simulated = false;
            transform.parent.position = Vector3.MoveTowards(transform.position, m_playerPosition, moveSpeed * Time.deltaTime);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.parent.position, playerRange);
    }
}
