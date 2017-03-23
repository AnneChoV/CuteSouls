using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {   //This class is used by both player and enemy as a storage for their stats. Things like movement speed are here in case they change according to equipment or enemy boss phase etc.

    public float health;
    public float movementSpeed;
    public float jumpHeight;
    public bool IsAffectedByGravity;

    //Couldn't think of a better place to put this, even though it's shared. :(
    public enum playerClass
    {
        TURTOISE,
        MELEE,
        PORCUPINE
    }

    public playerClass currentClass;
    
	void Start () {
        //facingDirection = new Vector2(1, 0);
        //attackingDirection = new Vector2(1, 0);
    }
	
	// Update is called once per frame
	void Update () {
		


	}

    void InitializeStats(float newhealth, float newMovementSpeed)
    {
        health = newhealth;
        movementSpeed = newMovementSpeed;
    }
}
