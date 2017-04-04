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
    public float timeUntilNextDamageTaken;

    public float blockingTimer;
    public float timeUntilBlockRunsOut;
    public float timeBetweenBlocks;
    public float timeUntilNextBlock;

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
            collision.GetComponent<CharacterStats>().TakeDamage(m_totalStats.m_DamageToOtherUponCollision);
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
        timeUntilNextDamageTaken -= Time.deltaTime;

        if (timeUntilNextDamageTaken <= 0.0f)
        {
            //CHARACTER IS IMMUNE TO ALL DAMAGE. MAKE IT BLINK A DIFFERENT COLOUR AND/OR PLAY A SOUND!
        }

        timeUntilBlockRunsOut -= Time.deltaTime;
        timeUntilNextBlock -= Time.deltaTime;
    }

    public virtual void EnvokeDeath()
    {
        Destroy(gameObject);

        //DEATH ANIMATION. DEATH PARTICLES. DEATH SOULS RELEASED. DIEDIEDIE SOUND.
    }
}
