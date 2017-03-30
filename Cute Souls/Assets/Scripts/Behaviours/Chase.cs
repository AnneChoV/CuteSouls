using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : BehaviourAbstract
{
    public bool MoveRight;

    public override void ActOnBehaviour(Vector3 _targetPosition)
    { 
        Vector3 movementDirection = m_playerPosition - transform.position;
<<<<<<< HEAD
        //Debug.Log(movementDirection.x);
        //Debug.Log(m_playerPosition);

        if (movementDirection.x > 0 && NotAtEdge())
=======
      //  Debug.Log(movementDirection.x);
      //      Debug.Log(m_playerPosition);
        if (movementDirection.x > 0)
>>>>>>> RefactorBranch
        {
            m_movementManager.HandleMoveRight();
        }
        else if (movementDirection.x < 0 && NotAtEdge())
        {
            m_movementManager.HandleMoveLeft();
        }
        else
        {
            // m_movementManager.HandleJumpStart(); //we'll get it to jump on the player once we have jumps resetting on ground touch.
        }

        // WE CAN CHECK FOR Y HERE TOO IF WE WANT
    }


}
