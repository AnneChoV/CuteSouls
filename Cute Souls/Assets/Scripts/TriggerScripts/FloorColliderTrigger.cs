using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliderTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsGrounded = true;
        other.GetComponent<CharacterStats>().isInAir = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsGrounded = false;
        if (other.GetComponent<CharacterStats>().IsOnLeftWall == false && other.GetComponent<CharacterStats>().IsOnRightWall == false)
        {
            other.GetComponent<CharacterStats>().isInAir = true;
        }
    }

}
