using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryHoldCertainDistance : BehaviourAbstract
{

    public override void ActOnBehaviour(Vector3 _targetPosition)
    {
        Vector3 movementDirection = m_playerPosition - transform.position;
        Debug.DrawLine(new Vector3(transform.position.x - 12, transform.position.y, transform.position.z), new Vector3(transform.position.x + 12, transform.position.y, transform.position.z));

        if (movementDirection.x + 10 > 0 && NotAtEdge())
        {
            m_movementManager.HandleMoveRight();
            Debug.Log("Right" + (movementDirection.x + 10));
        }


        if (movementDirection.x + 10 < 0 && NotAtEdge())
        {
            m_movementManager.HandleMoveLeft();
            Debug.Log("Left" + (movementDirection.x + 10));
        }

        else
        {
            Debug.Log("None");
        }

        //else
        //{
        //    // m_movementManager.HandleJumpStart(); //we'll get it to jump on the player once we have jumps resetting on ground touch.
        //}

        // WE CAN CHECK FOR Y HERE TOO IF WE WANT
    }

}
