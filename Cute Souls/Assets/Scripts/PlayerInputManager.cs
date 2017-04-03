using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {       //This class is used by player to handle input only.


    [Header("KeyCodes")]
    public KeyCode k_LeftKey = KeyCode.A;
    public KeyCode k_LeftKey2 = KeyCode.LeftArrow;
    public KeyCode k_RightKey = KeyCode.D;
    public KeyCode k_RightKey2 = KeyCode.RightArrow;
    public KeyCode k_JumpKey = KeyCode.W;
    public KeyCode k_JumpKey2 = KeyCode.UpArrow;
    public KeyCode k_ClassSwapKey = KeyCode.S;
    public KeyCode k_ClassSwapKey2 = KeyCode.DownArrow;
    // public KeyCode k_SwapClassKey = KeyCode.Space;
    public KeyCode k_MeleeAttack = KeyCode.Z;
    public KeyCode k_ClassSkill = KeyCode.X;

    [ReadOnly] public CharacterStats m_stats;
    [ReadOnly] public AttackMoves m_attackMoves;
    [ReadOnly] public MovementManager m_movementManager;

    void OnValidate()
    {
        m_stats = GetComponent<CharacterStats>();
        m_attackMoves = GetComponent<AttackMoves>();
        m_movementManager = GetComponent<MovementManager>();
    }

    private void Update()
    {
        CheckMovement();
        CheckClassSwap();
        CheckAbilities();
    }
                    //MOVEMENT
    private void CheckMovement()
    {
        //Left Right
        if (Input.GetKey(k_LeftKey) && !Input.GetKey(k_RightKey) && !Input.GetKeyDown(k_RightKey2) ||
            Input.GetKey(k_LeftKey2) && !Input.GetKey(k_RightKey) && !Input.GetKeyDown(k_RightKey2))
        {
            HandleMoveLeft();
        }
        else if (Input.GetKey(k_RightKey) && !Input.GetKey(k_LeftKey) && !Input.GetKey(k_LeftKey2) ||
            Input.GetKey(k_RightKey2) && !Input.GetKey(k_LeftKey) && !Input.GetKey(k_LeftKey2))
        {
            HandleMoveRight();
        }
        else
            HandleMoveNone();

        //Jumping
        if (Input.GetKeyDown(k_JumpKey) || Input.GetKeyDown(k_JumpKey2))
        {
            HandleJumpStart();
        }
        else if (Input.GetKeyUp(k_JumpKey) || Input.GetKeyDown(k_JumpKey2))
            HandleJumpRelease();
    }
                   //CLASS SWAPPING
    private void CheckClassSwap()
    {
        if (Input.GetKeyDown(k_ClassSwapKey) || Input.GetKeyDown(k_ClassSwapKey2))
        {
            HandleClassSwap();
        }
    }

    //LEFT RIGHT MOVE FUNCTIONS
    private void HandleMoveLeft()
    {
        m_movementManager.HandleMoveLeft();
    }

    private void HandleMoveRight()
    {
        m_movementManager.HandleMoveRight();
    }


    private void HandleMoveNone()
    {
        m_movementManager.HandleMoveNone();
    }

    //JUMP FUNCTIONS
    private void HandleJumpStart()
    {
        m_movementManager.HandleJumpStart();
    }

    private void HandleJumpRelease()
    {
        // m_movementManager.HandleJumpRelease();
    }


    private void HandleClassSwap()
    {
        m_stats.m_currentProtoclass.m_abilities[0].UseAbility();
    }

    private void CheckAbilities()
    {
        if (Input.GetKeyDown(k_MeleeAttack))
        {
            HandleMeleeAttack();
        }

        if (Input.GetKeyDown(k_ClassSkill))
        {

        }
    }

    private void HandleMeleeAttack()
    {
        m_stats.m_currentProtoclass.m_abilities[1].UseAbility(20, 5);
    }

    private void HandleClassSkill()
    {
       // m_stats.m_currentProtoclass.m_abilities[2].UseAbility();
    }
}
