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
        if (SceneManager.GetActiveScene().name == "Main Menu")
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
        StartCoroutine(LoadScene("FinalLevel"));
    }


    public void OptionsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
