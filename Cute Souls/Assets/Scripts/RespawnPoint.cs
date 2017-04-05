using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {
    public GameObject player;
    public CharacterStats playerStats;

    private void OnValidate()
    {
        player = Camera.main.transform.parent.gameObject;
        playerStats = player.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 1.5f)
        {
            playerStats.RespawnPoint = transform.position;
            playerStats.m_currentHealth = playerStats.m_TotalStats.m_Health;
        }
    }
}
