using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItemTowardsPlayerInRange : MonoBehaviour {
    public GameObject player;

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
                        break;
                    case 1:
                        player.GetComponent<Mouse>().m_currentClassSkillTier++;
                        break;
                    case 2:
                        player.GetComponent<Tortoise>().m_currentClassSkillTier++;
                        break;
                    default:
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
