using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                NewButton();
            }
        }
    }

    IEnumerator Fading()
    {
        float fadeTime = GameObject.Find("Game Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }


    IEnumerator LoadScene(string sceneName)
    {
        float fadeTime = GameObject.Find("Game Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
       
        SceneManager.LoadScene(sceneName);
        soundManager.playTheme(sceneName);

        if (sceneName == "Test_Campfire")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       // FindObjectOfType<Fader>().OnLevelWasLoaded();
    }

    public void SceneLoad(string SceneName)
    {
        StartCoroutine(LoadScene(SceneName));
    }

    public void restartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NewButton()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(LoadScene("IntroScene"));
    }


    public void OptionsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
