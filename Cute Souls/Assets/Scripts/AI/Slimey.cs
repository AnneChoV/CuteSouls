using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimey : AbstractEnemy
{
    // Update is called once per frame
    void Update ()
    {
        movementManager.HandleMoveLeft();
	}
}
