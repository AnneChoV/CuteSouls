using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliderTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsGrounded = true;
        other.GetComponent<CharacterStats>().isInAir = false;
        Debug.Log("Entering");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsGrounded = true;
        other.GetComponent<CharacterStats>().isInAir = false;
        Debug.Log("dgxdfgfddgf");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
        other.GetComponent<CharacterStats>().IsGrounded = false;
        if (other.GetComponent<CharacterStats>().IsOnLeftWall == false && other.GetComponent<CharacterStats>().IsOnRightWall == false)
        {
            Debug.Log("Exiting");
            other.GetComponent<CharacterStats>().isInAir = true;
        }
    }

}
