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
}
