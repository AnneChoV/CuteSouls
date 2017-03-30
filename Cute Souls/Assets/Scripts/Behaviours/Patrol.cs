using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BehaviourAbstract
{
    private bool moveRight;

    public override void ActOnBehaviour(Vector3 _targetPosition)
    {
        Debug.Log(NotAtEdge());

        if (!NotAtEdge())
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            m_movementManager.HandleMoveRight();
        }

        else
        {
            m_movementManager.HandleMoveLeft();
        }
    }


}
