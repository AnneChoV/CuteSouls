using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public GameObject statsWindow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("i"))
        {
            if (statsWindow.activeInHierarchy == true)
            {
                statsWindow.SetActive(false);
            }
            else
            {
                statsWindow.SetActive(true);
            }
        }
	}

    public void StatsClick()
    {
        if (statsWindow.activeInHierarchy == true)
        {
            statsWindow.SetActive(false);
        }
        else
        {
            statsWindow.SetActive(true);
        }
    }
}
