using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archetype : MonoBehaviour {

    public StatsTemplate m_classDefaultStats;
    public Ability[] m_abilities;
    public BehaviourAbstract[] m_behaviours;
    public RuntimeAnimatorController animatorController;

    public StatsTemplate m_EquipmentStats;  //LATER ON THIS SHOULD BE READ ONLY AND UPDATE WITH CURRENT PLAYER EQUIPMENT.

    [ReadOnly]
    public StatsTemplate m_totalStats;

    public float immunityFramesNumber;
    [ReadOnly]

    //public float timeUntilNextDamageTaken;

    //public float blockingtimer;
    //public float timeUntilBlockRunsOut;
    //public float timeBetweenBlocks;
    //public float timeUntilNextBlock;

    public bool isDead = false;
    public float respawnTime = 2.0f;
    public float respawnTimer = 2.0f;

    public int m_currentClassSkillTier; //USED FOR PLAYER ONLY

    private void OnValidate()
    {
        m_abilities = GetComponentsInChildren<Ability>();
        m_behaviours = GetComponentsInChildren<BehaviourAbstract>();

        m_totalStats = m_classDefaultStats.Add(m_EquipmentStats);
    }

    private void OnTriggerStay2D(Collider2D collision) //lose health
    {
        if (collision.gameObject.name == "Player")
        {
            collision.GetComponent<CharacterStats>().TakeDamage(m_totalStats.m_DamageToOtherUponCollision, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
        }
    }

    public virtual void Update()
    {
        Debug.Log("Updating");
       if (isDead == true)
        {
            Debug.Log("ded");
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0.0f)
            {
                Debug.Log("Respawning");
                Respawn();
            }
        }
    }

    public virtual void EnvokeDeath()
    {
        if (GetComponent<Player>())
        {
            isDead = true;
        }
        else
        {
            Destroy(gameObject);
        }

        //DEATH ANIMATION. DEATH PARTICLES. DEATH SOULS RELEASED. DIEDIEDIE SOUND.
    }

    public void Respawn()
    {
        transform.position = GetComponent<CharacterStats>().RespawnPoint;
        isDead = false;
    }
}
