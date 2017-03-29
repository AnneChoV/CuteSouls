using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMovement : BehaviourAbstract
{ 
    public override void ActOnBehaviour(Vector3 _targetPosition)
    {
        //Left blank on purpose, friction should bring the character to a halt.
    }
}
