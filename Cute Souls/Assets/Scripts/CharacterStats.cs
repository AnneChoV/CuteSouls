using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public float health;
    public float movementSpeed;
    public Vector2 facingDirection;
    public Vector2 attackingDirection;
    
	void Start () {
        facingDirection = new Vector2(1, 0);
        attackingDirection = new Vector2(1, 0);
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
