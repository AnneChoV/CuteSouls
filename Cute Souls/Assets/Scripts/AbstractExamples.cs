
//public abstract class AbstractAbility
//{
//    public string m_AbilityName;

//    public void DoDamageToSomething(object _obj)
//    {
//        // Does damage to an object
//        string damageQuote = _obj.ToString() + " took some damage wow.";
//    }

//    // No functionality
//    public abstract void UseAbility();

//}

//public class GenericRealAbility : AbstractAbility
//{
//    public int m_Damage;
//    public int m_Range;

//    // Actual functionality
//    public override void UseAbility()
//    {
//        // What the ability does

//        // Can also call abstract functions
//        DoDamageToSomething(this);
//    }
//}

//public class Archetype
//{
//    // My three abilities (they could all be completely different abilities - SO LONG AS THEY INHERIT FROM ABSTRACT ABILITY
//    public AbstractAbility[] m_AllMyAbilities =
//    {
//        new GenericRealAbility(),
//        new GenericRealAbility(),
//        new GenericRealAbility()
//    };

//    // Random function 
//    public void Update()
//    {
//        // Use ability with the functionality of the children
//        m_AllMyAbilities[0].UseAbility();
//        string greatQuote = m_AllMyAbilities[1].m_AbilityName + " is the greatest ability.";
//    }
//}

using System;

public abstract class Ability
{
    public abstract void UseAbility();
}

public class AbilityType1 : Ability
{
    public override void UseAbility()
    {
        // Functionality of ability here
    }
}

// ....

public struct CharacterStats
{
    // All the character stat values
}

public class StatsManager
{
    public CharacterStats m_BaseStats;
    public CharacterStats m_CurrentStats;

    // Functionality to use inventory/whatever else to influence current stats
}

public class Archetype
{
    public CharacterStats m_BaseStats;
    public Ability[] m_Abilities;
}

public class Character
{
    public Archetype[] m_Archetypes;

    public StatsManager m_Stats;
    public int m_Health;
    public int m_OtherShit;
}

// +

public class CharacterMovement
{ }

public class PlayerInput
{ }

// etc. 