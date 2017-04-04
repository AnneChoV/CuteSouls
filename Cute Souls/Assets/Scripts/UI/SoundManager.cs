using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public AudioSource themeSource;
    public AudioSource efxSource;

    public AudioClip mainMenu;
    public AudioClip caveTheme;
    public AudioClip fireplaceTheme;

    public AudioClip rockFall;
    public AudioClip rockFall2;
    public AudioClip bagSearch;
    public AudioClip punch;
    public AudioClip startFire;
    public AudioClip digging;


    private AudioClip selectedTheme;
    //public AudioClip[] starClicks;

    public static SoundManager instance = null;

    // Use this for initialization
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            selectedTheme = mainMenu;
        }

        efxSource = GameObject.Find("Sound Manager").GetComponent<AudioSource>();
        themeSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();

        themeSource.PlayOneShot(selectedTheme, 0.5f);

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
        if (sceneName == "PrototypeCave")
        {
            selectedTheme = caveTheme;
            themeSource.PlayOneShot(selectedTheme);
        }

        if (sceneName == "IntroScene")
        {
            efxSource.PlayOneShot(rockFall, 0.6f);
            efxSource.PlayOneShot(rockFall2, 0.6f);
            selectedTheme = caveTheme;
            themeSource.clip = selectedTheme;
            themeSource.PlayDelayed(4.0f);
            themeSource.volume = 0.1f;
        }

        
        if (sceneName == "Test_Campfire")
        {
            themeSource.Stop();
            selectedTheme = fireplaceTheme;
            themeSource.PlayOneShot(selectedTheme);
        }
    }

    public void Digging()
    {
        efxSource.PlayOneShot(digging);
    }
    public void BagSearch()
    {
        efxSource.PlayOneShot(bagSearch, 1.9f);
    }

    public void Punch()
    {
        efxSource.PlayOneShot(punch);
    }

    public void StartFire()
    {
        efxSource.PlayOneShot(startFire);
        selectedTheme = fireplaceTheme;
        themeSource.clip = selectedTheme;
        themeSource.PlayDelayed(2.0f);
        themeSource.volume = 0.6f;
    }
}
