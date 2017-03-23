using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour {  //This is a class shared by players and enemies to handle different attacks.

    [ReadOnly] public CharacterStats m_Stats;

    void OnValidate()
    {
        m_Stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void UsePlayerClassAttack(int currentClass)
    {
        if (currentClass == 0)  //We need some attacks D:
        {

        }
        else if (currentClass == 1)
        {

        }
        else if (currentClass == 2)
        {

        }
    }

    public void HandleClassSwap()
    {
        m_Stats.currentClass = (CharacterStats.playerClass)(((((int)(m_Stats.currentClass)) + 1) % 3)); //Casts currentClass into int, adds one, modulus 3 to get a number between 0 and 2, then converts back to the enum.
    }

    public void MeleeFrontAttack()    //Attack in front.
    {

    }

    public void ProjectileFrontAttack()
    {

    }
}
