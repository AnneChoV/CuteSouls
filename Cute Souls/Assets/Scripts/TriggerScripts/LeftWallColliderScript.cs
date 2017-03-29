﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallColliderScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsOnLeftWall = true;
        other.GetComponent<CharacterStats>().isInAir = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CharacterStats>().IsOnLeftWall = false;
        if (other.GetComponent<CharacterStats>().IsGrounded == false && other.GetComponent<CharacterStats>().IsOnRightWall == false)
        {
            other.GetComponent<CharacterStats>().isInAir = true;
        }
    }
}
