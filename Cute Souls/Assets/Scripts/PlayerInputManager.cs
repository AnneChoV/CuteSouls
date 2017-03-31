using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {       //This class is used by player to handle input only.


    [Header("KeyCodes")]
    public KeyCode k_LeftKey = KeyCode.A;
    public KeyCode k_RightKey = KeyCode.D;
    public KeyCode k_JumpKey = KeyCode.W;
    public KeyCode k_ClassSwapKey = KeyCode.S;
    public KeyCode k_SkillKey = KeyCode.Space;

    [ReadOnly] public CharacterStats m_stats;
    [ReadOnly] public AttackMoves m_attackMoves;
    [ReadOnly] public MovementManager m_movementManager;

    void OnValidate()  
    {
        m_stats = GetComponent<CharacterStats>();
        m_attackMoves = GetComponent<AttackMoves>();
        m_movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        CheckMovement();
        CheckCast();
        CheckClassSwap();
    }



    private void CheckMovement()
    {
        //LEFT RIGHT
        if (Input.GetKey(k_LeftKey) && !Input.GetKey(k_RightKey))
            HandleMoveLeft();
        else if (Input.GetKey(k_RightKey) && !Input.GetKey(k_LeftKey))
            HandleMoveRight();
        else
            HandleMoveNone();

        //JUMPING
        if (Input.GetKeyDown(k_JumpKey))
            HandleJumpStart();
        else if (Input.GetKeyUp(k_JumpKey))
            HandleJumpRelease();
    }

    //LEFT RIGHT MOVE FUNCTIONS
    void HandleMoveLeft()
    {
        m_movementManager.HandleMoveLeft();
    }

    void HandleMoveRight()
    {
        m_movementManager.HandleMoveRight();
    }


    void HandleMoveNone()
    {
        m_movementManager.HandleMoveNone();
    }

    //JUMP FUNCTIONS
    void HandleJumpStart()
    {
        m_movementManager.HandleJumpStart();
    }

    void HandleJumpRelease()
    {
        // m_movementManager.HandleJumpRelease();
    }

    //CASTING FUNCTIONS
    void CheckCast()
    {
        if (Input.GetKeyDown(k_SkillKey))
        {
            HandleCast();
        }
    }

    void HandleCast()
    {
       // m_attackMoves.UsePlayerClassAttack((int)m_stats.currentClass);
    }

    void CheckClassSwap()
    {
        if (Input.GetKeyDown(k_ClassSwapKey))
        {
            HandleClassSwap();
        }
    }

    void HandleClassSwap()
    {
        m_stats.m_currentProtoclass.m_abilities[0].UseAbility();
    }
}
