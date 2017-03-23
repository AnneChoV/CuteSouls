using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {  //This is a class shared by player and enemies to handle movements.

    //    //Should make own force for left and right cause the unity rigidbody one is shit for this.
    public Vector2 facingDirection;
    public Vector2 attackingDirection;

    [ReadOnly] public Rigidbody2D m_rigidBody;
    [ReadOnly] public CharacterStats m_Stats;

    void OnValidate()
    {
        m_Stats = GetComponent<CharacterStats>();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleMoveLeft()
    {
        m_rigidBody.AddForce(new Vector2(-m_Stats.movementSpeed, 0.0f), ForceMode2D.Force);
        Mathf.Clamp(m_rigidBody.velocity.x, -10.0f, 10.0f); //Keep it between those values
        if (m_rigidBody.velocity.x < -10.0f)
        {
            m_rigidBody.velocity = new Vector2(-10.0f, m_rigidBody.velocity.y);
        }
    }

    public void HandleMoveRight()
    {
        m_rigidBody.AddForce(new Vector2(m_Stats.movementSpeed, 0.0f), ForceMode2D.Force);
        Mathf.Clamp(m_rigidBody.velocity.x, -10.0f, 10.0f); //Keep it between those values
        if (m_rigidBody.velocity.x > 10.0f)
        {
            m_rigidBody.velocity = new Vector2(10.0f, m_rigidBody.velocity.y);
        }
    }


    public void HandleMoveNone()    //Idle Animation?
    {

    }

    //JUMP FUNCTIONS
    public void HandleJumpStart()
    {
        m_rigidBody.AddForce(new Vector2(0, m_Stats.jumpHeight), ForceMode2D.Impulse);
    }

    public void HandleJumpRelease()
    {

    }
}
