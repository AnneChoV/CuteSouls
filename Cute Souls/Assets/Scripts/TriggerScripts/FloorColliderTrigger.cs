using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliderTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterStats currentCharacterStats;
        currentCharacterStats = other.GetComponent<CharacterStats>();
        if (currentCharacterStats)
        {
            currentCharacterStats.IsGrounded = true;
            currentCharacterStats.jumpsAvailable = other.GetComponent<CharacterStats>().m_TotalStats.m_jumpsTotal;
            currentCharacterStats.isInAir = false;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CharacterStats currentCharacterStats;
        currentCharacterStats = other.GetComponent<CharacterStats>();
        if (currentCharacterStats)
        {
            currentCharacterStats.IsGrounded = true;
            currentCharacterStats.isInAir = false;
       //     currentCharacterStats.jumpsAvailable = other.GetComponent<CharacterStats>().m_TotalStats.m_jumpsTotal;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterStats currentCharacterStats;
        //Debug.Log("THIS1");
        currentCharacterStats = other.GetComponent<CharacterStats>();
        if (currentCharacterStats)
        {
            currentCharacterStats.IsGrounded = false;
          //  if (currentCharacterStats.IsOnLeftWall == false && other.GetComponent<CharacterStats>().IsOnRightWall == false)
            {
                currentCharacterStats.isInAir = true;
         //       Debug.Log("THIS2");
                currentCharacterStats.m_TotalStats.m_jumpsTotal--;
            }
        }
    }

}
