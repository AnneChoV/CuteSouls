using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [ReadOnly] public Archetype tortoise;
    [ReadOnly] public Archetype porcupine;
    [ReadOnly] public Archetype mouse;



    private void OnValidate()
    {
        tortoise = GetComponent<Tortoise>();
        porcupine = GetComponent<Porcupine>();
        mouse = GetComponent<Mouse>();
    }
    void Update() {
        // Raycasting all objects with enemy tag, left and right
        RaycastHit2D[] leftHit = Physics2D.RaycastAll(transform.position, -transform.right, 5.0f);
        RaycastHit2D[] rightHit = Physics2D.RaycastAll(transform.position, transform.right, 5.0f);

        for (int i = 0; i < leftHit.Length; i++)
        {
            if (leftHit[i].collider.tag == "Enemy")
            {
                RaycastHit2D hit = leftHit[i];

                Debug.Log("There is an enemy to my left!");
                Debug.Log(hit.collider.name);
            }

           
        }

        for (int i = 0; i < rightHit.Length; i++)
        {
            if (rightHit[i].collider.tag == "Enemy")
            {
                RaycastHit2D hit = rightHit[i];

                Debug.Log("There is an enemy to my right!");
                Debug.Log(hit.collider.name);
            }
        }
 


    }
}
