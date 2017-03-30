﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : BehaviourAbstract
{
    public override void ActOnBehaviour(Vector3 _targetPosition)
    { 
        Vector3 movementDirection = m_playerPosition - transform.position;

        //Debug.Log(movementDirection.x);
        //Debug.Log(m_playerPosition);

        //&& NotAtEdge()
        if (movementDirection.x > 0 && NotAtEdge())
        {
            Debug.Log("Moving right");
            m_movementManager.HandleMoveRight();
        }


         //&& NotAtEdge()
        else if (movementDirection.x < 0 && NotAtEdge())
        {
            Debug.Log("Moving Left");
            m_movementManager.HandleMoveLeft();
        }
        else 
        {
            Debug.Log("Stopping");
            // m_movementManager.HandleJumpStart(); //we'll get it to jump on the player once we have jumps resetting on ground touch.
        }

        // WE CAN CHECK FOR Y HERE TOO IF WE WANT
    }



}
