using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{
    public GameObject Exit;

    public void Start()
    {
        Exit.SetActive(false);
    }

    public void PlayButton()
    {
        DontDestroy.Instance.PlaySomeSounds();
        SceneManager.LoadScene("GameSelection");
    }
    public void SettingsButton()
    {
        DontDestroy.Instance.PlaySomeSounds();
        SceneManager.LoadScene("SettingsMenu");
        Debug.Log("Настройки");
    }
    public void ExitButton()
    {
        DontDestroy.Instance.PlaySomeSounds();
        Exit.SetActive(true);
        //Application.Quit();
    }

    public void ExitExitButton()
    {
        DontDestroy.Instance.PlaySomeSounds();
        Application.Quit();
    }

    public void NoExitButton()
    {
        DontDestroy.Instance.PlaySomeSounds();
        Exit.SetActive(false);
    }
}
