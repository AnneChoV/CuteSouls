using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveItemTowardsPlayerInRange : MonoBehaviour {
    public GameObject player;

    public Text gemTextBox;

    public int gemType;

    private void OnValidate()
    {
        player = Camera.main.transform.parent.gameObject;
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 5.0f)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 1.5f)
            {
                switch (gemType)
                {
                    case 0:
                        player.GetComponent<Porcupine>().m_currentClassSkillTier++;
                        gemTextBox.text = "You got a Dash Gem!";
                        break;
                    case 1:
                        player.GetComponent<Mouse>().m_currentClassSkillTier++;
                        gemTextBox.text = "You got a Parry Gem!";
                        break;
                    case 2:
                        player.GetComponent<Tortoise>().m_currentClassSkillTier++;
                        gemTextBox.text = "You got a Block Gem!";
                        break;
                    case 3:
                        player.GetComponent<CharacterStats>().canClassSwap = true;
                        gemTextBox.text = "You got the ClassSwap Gem! Press the down Arrow to Class swap!";
                        break;
                    case 4:
                        player.GetComponent<CharacterStats>().canAttack = true;
                        gemTextBox.text = "You got the Attack Gem! Press the Z key to attack!";
                        break;
                    default:
                        Debug.Log("ERROR HERE, GEM TYPE WRONG");
                        break;
                }
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.1f);
            }
        }
    }
}
