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
        Debug.Log("������");
        SceneManager.LoadScene("GameSelection");
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsMenu");
        Debug.Log("���������");
    }
    public void ExitButton()
    {
        Exit.SetActive(true);
        //Application.Quit();
    }

    public void ExitExitButton()
    {
        Application.Quit();
    }

    public void NoExitButton()
    {
        Exit.SetActive(false);
    }
}
