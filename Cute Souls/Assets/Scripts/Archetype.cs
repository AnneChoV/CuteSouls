using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archetype : MonoBehaviour {

    public StatsTemplate m_classDefaultStats;
    public Ability[] m_abilities;

    public StatsTemplate m_EquipmentStats;  //LATER ON THIS SHOULD BE READ ONLY AND UPDATE WITH CURRENT PLAYER EQUIPMENT.
}
