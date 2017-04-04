using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porcupine : Archetype {
    public GameObject playerProjectile;


    public override void EnvokeDeath()
    {
       // base.EnvokeDeath(); //DEFINATELY DONT DO THIS, IT WILL DESTROY THE PLAYER ON DEATH!!

        //We need to set the players position to the last checkpoint.
    }
}
