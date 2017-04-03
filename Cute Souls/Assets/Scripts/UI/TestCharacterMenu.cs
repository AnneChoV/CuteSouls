using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacterMenu : MonoBehaviour {

    [Header("Stats")]
    [Range(0, 3)]
    [ReadOnly]
    public int attackPower;

    [Range(0, 3)]
    [ReadOnly]
    public int speed;

    [Range(0, 3)]
    [ReadOnly]
    public int defense;

    [Range(0, 3)]
    [ReadOnly]
    public int parry;

    [Range(0, 3)]
    [ReadOnly]
    public int dash;

    [Range(0, 3)]
    [ReadOnly]
    public int block;
    [Space(5)]

    [Header("Game Objects")]
    public GameObject Portrait;
    public GameObject[] AttackPower;
    public GameObject[] Speed;
    public GameObject[] Defense;
    public GameObject[] Parry;
    public GameObject[] Dash;
    public GameObject[] Block;
    [Space(5)]

    [Header("Sprites")]
    public Sprite Mouse;
    public Sprite Porc;
    public Sprite Tort;
    public Sprite Sword;
    public Sprite Boot;
    public Sprite Shield;
    public Sprite Hex;
    public Sprite Triangle;
    public Sprite Square;

    public Sprite noSword;
    public Sprite noBoot;
    public Sprite noShield;
    public Sprite noHex;
    public Sprite noTriangle;
    public Sprite noSquare;

    // Use this for initialization
    void Start () {
        checkClass();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkClass()
    {
        if (GameObject.Find("MouseToggle").GetComponent<Toggle>().isOn == true)
        {
            attackPower = 3;
            defense = 2;
            speed = 2;
        }
        if (GameObject.Find("PorcupineToggle").GetComponent<Toggle>().isOn == true)
        {
            attackPower = 2;
            defense = 1;
            speed = 3;
        }
        if (GameObject.Find("TortoiseToggle").GetComponent<Toggle>().isOn == true)
        {
            attackPower = 1;
            defense = 3;
            speed = 1;
        }

        ApplyStats();
    }

    // Checks stat values and displays
    public void ApplyStats()
    {
        // Reset all before applying
        for (int i = 0; i < 3; i++)
        {
            AttackPower[i].GetComponent<Image>().sprite = noSword;
            Speed[i].GetComponent<Image>().sprite = noBoot;
            Defense[i].GetComponent<Image>().sprite = noShield;
            Parry[i].GetComponent<Image>().sprite = noHex;
            Dash[i].GetComponent<Image>().sprite = noTriangle;
            Block[i].GetComponent<Image>().sprite = noSquare;
        }

        for (int i = 0; i < attackPower; i++)
        {
            AttackPower[i].GetComponent<Image>().sprite = Sword;
        }

        for (int i = 0; i < speed; i++)
        {
            Speed[i].GetComponent<Image>().sprite = Boot;
        }

        for (int i = 0; i < defense; i++)
        {
            Defense[i].GetComponent<Image>().sprite = Shield;
        }

        for (int i = 0; i < parry; i++)
        {
            Parry[i].GetComponent<Image>().sprite = Hex;
        }

        for (int i = 0; i < dash; i++)
        {
            Dash[i].GetComponent<Image>().sprite = Triangle;
        }

        for (int i = 0; i < block; i++)
        {
            Block[i].GetComponent<Image>().sprite = Square;
        }
    }

    public void changePortrait()
    {
        if (GameObject.Find("MouseToggle").GetComponent<Toggle>().isOn == true)
        {
            Portrait.GetComponent<Image>().sprite = Mouse;
            checkClass();
        }
        if (GameObject.Find("PorcupineToggle").GetComponent<Toggle>().isOn == true)
        {
            Portrait.GetComponent<Image>().sprite = Porc;
            checkClass();
        }
        if (GameObject.Find("TortoiseToggle").GetComponent<Toggle>().isOn == true)
        {
            Portrait.GetComponent<Image>().sprite = Tort;
            checkClass();
        }
    }
}
