using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{  //This is a class shared by player and enemies to handle movements.

    [ReadOnly]
    public bool isfacingRight;
    [ReadOnly]
    public Vector2 m_attackingDirection;

    [ReadOnly]
    public Rigidbody2D m_rigidBody;
    [ReadOnly]
    public CharacterStats m_Stats;
    [ReadOnly]
    public Animator m_animator;
    public SpriteRenderer spriteRenderer;
    [ReadOnly]
    public SoundManager soundManager;

    void OnValidate()
    {
        isfacingRight = true;
        m_Stats = GetComponent<CharacterStats>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        isfacingRight = true;
        m_animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        m_rigidBody.gravityScale = m_Stats.m_TotalStats.m_jumpSpeedGravityScale;    //FIND BETTER WAY?
        if (m_Stats.m_currentProtoclass.m_totalStats.doesGetStuckOnWalls == true)
        {
            if (m_Stats.IsOnLeftWall || m_Stats.IsOnRightWall)
            {
                //We can't slow it. Its too hard :<
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
    }

    // Update is called once per frame

    public void HandleMoveLeft()
    {
        float efficacy;
        if (m_rigidBody.velocity.x > 0)
        {
            efficacy = 1.0f;
        }
        else
        {
            efficacy = 1.0f - Mathf.Clamp(Mathf.Abs(m_rigidBody.velocity.x) / m_Stats.m_TotalStats.m_maxSpeed, 0.01f, 1.0f);
        }
        if (m_Stats.IsGrounded)   //If grounded
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * -1 * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
            if (m_animator)
            {
                m_animator.SetBool("IsMoving", true);
                m_animator.SetBool("IsJumping", false);
            }            
        }
        else if (m_Stats.isInAir)
        {
            if (m_animator)
            {
                m_animator.SetBool("IsJumping", true);
            }
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_airAcceleration * m_Stats.m_TotalStats.m_airAcceleration * -1 * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else if (m_Stats.IsOnLeftWall)
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * -1 * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else if (m_Stats.IsOnRightWall)
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * -1 * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else
        {
            Debug.Log("This case should never be reached. Something's wrong.");
            return;
        }
        isfacingRight = false;        
        spriteRenderer.flipX = true;
    }

    public void HandleMoveRight()
    {
        float efficacy;
        if (m_rigidBody.velocity.x < 0)
        {
            efficacy = 1.0f;
        }
        else
        {
            efficacy = 1.0f - Mathf.Clamp(Mathf.Abs(m_rigidBody.velocity.x) / m_Stats.m_TotalStats.m_maxSpeed, 0.01f, 1.0f);
        }

        if (m_Stats.IsGrounded)   //If grounded
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
            if (m_animator)
            {
                m_animator.SetBool("IsMoving", true);
                m_animator.SetBool("IsJumping", false);
            }
        }
        else if (m_Stats.isInAir)
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_airAcceleration * m_Stats.m_TotalStats.m_airAcceleration * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else if (m_Stats.IsOnLeftWall)
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale * m_Stats.m_TotalStats.m_airAcceleration / 100, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else if (m_Stats.IsOnRightWall)
        {
            m_rigidBody.AddForce(new Vector2(m_Stats.m_TotalStats.m_Acceleration * m_Stats.m_TotalStats.m_Acceleration * efficacy * m_Stats.m_TotalStats.m_jumpSpeedGravityScale * m_Stats.m_TotalStats.m_airAcceleration / 100, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
        }
        else
        {
            Debug.Log("This case should never be reached. Something's wrong.");
            return;
        }

            spriteRenderer.flipX = false;
            isfacingRight = true;
        
    }


    public void HandleMoveNone()    //Idle Animation?
    {
        float efficacy = Mathf.Abs(m_rigidBody.velocity.x) - m_Stats.m_TotalStats.m_groundFriction;
        {
            if (m_Stats.IsGrounded)
            {
                m_animator.SetBool("IsMoving", false);
                m_animator.SetBool("IsJumping", false);
                m_rigidBody.AddForce(new Vector2(-m_rigidBody.velocity.x * m_Stats.m_TotalStats.m_groundFriction * 2.0f, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
                
                if (Mathf.Abs(m_rigidBody.velocity.x) < 1.0f)
                {
                    m_rigidBody.velocity = new Vector3(0.0f, m_rigidBody.velocity.y, 0.0f);
                }
            }
               
            else if (m_Stats.isInAir)
            {
                m_animator.SetBool("IsJumping", true);
                m_rigidBody.AddForce(new Vector2(-m_rigidBody.velocity.x * m_Stats.m_TotalStats.m_AirFriction, 0.0f) * Time.deltaTime / Time.timeScale, ForceMode2D.Force);
            }
        }
    }

    //JUMP FUNCTIONS
    public void HandleJumpStart()
    {
        if (m_Stats.jumpsAvailable > 0 && m_Stats.jumpTime < Time.time + m_Stats.jumpWaitDelay)
        {
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 0.0f);
            m_rigidBody.AddForce(new Vector2(0, m_Stats.m_TotalStats.m_jumpHeight * m_Stats.m_TotalStats.m_jumpSpeedGravityScale / 4), ForceMode2D.Impulse);

            m_Stats.jumpsAvailable--;
            m_animator.SetBool("IsJumping", true);
            if (soundManager)
            {
                soundManager.Jump();
            }
            m_Stats.jumpTime = Time.time;
        }
        else
        {
            Debug.Log("Can't jump sorry - xoxo gossip");
        }
    }

    public void HandleLeftWallSlide()
    {

    }
}
