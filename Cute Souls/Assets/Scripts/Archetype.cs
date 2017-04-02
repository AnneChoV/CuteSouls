﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archetype : MonoBehaviour {

    public StatsTemplate m_classDefaultStats;
    public Ability[] m_abilities;
    public BehaviourAbstract[] m_behaviours;
    public RuntimeAnimatorController animatorController;



    public StatsTemplate m_EquipmentStats;  //LATER ON THIS SHOULD BE READ ONLY AND UPDATE WITH CURRENT PLAYER EQUIPMENT.

    private void OnValidate()
    {
        m_abilities = GetComponentsInChildren<Ability>();
        m_behaviours = GetComponentsInChildren<BehaviourAbstract>();
    }
}
