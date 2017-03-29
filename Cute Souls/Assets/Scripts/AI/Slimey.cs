using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    void Update ()
    {
        m_currentBehaviour.ActOnBehaviour();    //This should make it move how we want.
    }
}
