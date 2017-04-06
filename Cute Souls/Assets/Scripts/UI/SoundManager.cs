using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public AudioSource themeSource;
    public AudioSource efxSource;

    public AudioClip mainMenu;
    public AudioClip gameTheme;
    public AudioClip gameTheme2;

    public AudioClip powerUp;
    public AudioClip umbrellaHit;
    public AudioClip spikeThrow;
    public AudioClip shieldBlock;
    public AudioClip jump;
    public AudioClip parry;


    private AudioClip selectedTheme;
    //public AudioClip[] starClicks;

    public static SoundManager instance = null;

    // Use this for initialization
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            selectedTheme = mainMenu;
        }

        efxSource = GameObject.Find("Sound Manager").GetComponent<AudioSource>();
        themeSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();

        //themeSource.PlayOneShot(selectedTheme, 0.5f);
        themeSource.clip = selectedTheme;
        themeSource.Play();

        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    public void playTheme(string sceneName)
    {
        if (sceneName == "Intro_1")
        {
            selectedTheme = gameTheme;
            themeSource.clip = selectedTheme;
            themeSource.Play();
        }

        if (sceneName == "FinalLevel")
        {
            selectedTheme = gameTheme;
            themeSource.clip = selectedTheme;
            themeSource.Play();
        }
    }

    public void Jump()
    {
        efxSource.PlayOneShot(jump);
    }
    public void UmbrellaHit()
    {
        efxSource.PlayOneShot(umbrellaHit);
    }

    public void SpikeThrow()
    {
        efxSource.PlayOneShot(spikeThrow);
    }

    public void ShieldBlock()
    {
        efxSource.PlayOneShot(shieldBlock);
    }

    public void Parry()
    {
        efxSource.PlayOneShot(parry, 0.6f);
    }
}
