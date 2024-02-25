using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{

    public void PlayButton()
    {
        Debug.Log("Играть");
        SceneManager.LoadScene("GameSelection");
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsMenu");
        Debug.Log("Настройки");
    }
    public void ExitButton()
    {
        Debug.Log("Выход");
        Application.Quit();
    }
}
