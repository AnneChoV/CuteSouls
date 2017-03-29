using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{

    public GameObject InventoryPanel;
    public GameObject StatsPanel;

    public GameObject PanelButtons;

    private bool ButtonState = false;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseMenuButton()
    {

        if (ButtonState == false)
        {
            InventoryPanel.SetActive(true);
            PanelButtons.SetActive(true);

            ButtonState = true;
        }
        else
        {
            InventoryPanel.SetActive(false);
            StatsPanel.SetActive(false);

            PanelButtons.SetActive(false);

            ButtonState = false;
        }
    }


    public void InventoryButton()
    {
        if (InventoryPanel.activeInHierarchy == false)
        {
            InventoryPanel.SetActive(true);
        }

        if (StatsPanel.activeInHierarchy == true)
        {
            StatsPanel.SetActive(false);
        }
    }

    public void StatsButton()
    {
        if (InventoryPanel.activeInHierarchy == true)
        {
            InventoryPanel.SetActive(false);
        }

        if (StatsPanel.activeInHierarchy == false)
        {
            StatsPanel.SetActive(true);
        }

    }

}
