using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallColliderScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsOnRightWall = true;
        other.GetComponent<CharacterStats>().isInAir = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsOnRightWall = false;
        if (other.GetComponent<CharacterStats>().IsGrounded == false && other.GetComponent<CharacterStats>().IsOnLeftWall == false)
        {
            other.GetComponent<CharacterStats>().isInAir = true;
        }
    }
}
