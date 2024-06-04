using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectionButtons : MonoBehaviour
{
    public GameObject ButtonsSelection;
    public GameObject NumberPlayers;

    string select;
    int NumPlayer = 0;


    void Start()
    {
        ButtonsSelection.SetActive(true);
        NumberPlayers.SetActive(false);
    }

    public void OrnamentGame()
    {
        DontDestroy.Instance.PlaySomeSounds();
        //SceneManager.LoadScene("OrnamentGame");
        ButtonsSelection.SetActive(false);
        select = "OrnamentGame";
        NumberPlayers.SetActive(true);
    }

    public void GameWords()
    {
        DontDestroy.Instance.PlaySomeSounds();
        //SceneManager.LoadScene("WordsGame");
        ButtonsSelection.SetActive(false);
        select = "WordsGame";
        NumberPlayers.SetActive(true);
    }
    
    public void ClothesGame()
    {
        DontDestroy.Instance.PlaySomeSounds();
        //SceneManager.LoadScene("clothes");
        ButtonsSelection.SetActive(false);
        select = "clothes";
        NumberPlayers.SetActive(true);
    }

    public void PuzzleGame()
    {
        DontDestroy.Instance.PlaySomeSounds();
        //SceneManager.LoadScene("GamePazli");
        ButtonsSelection.SetActive(false);
        select = "GamePazli";
        NumberPlayers.SetActive(true);
    }
    
    public void PairGame()
    {
        DontDestroy.Instance.PlaySomeSounds();
        //SceneManager.LoadScene("Pair");
        ButtonsSelection.SetActive(false);
        select = "Pair";
        NumberPlayers.SetActive(true);
    }

    public void Back()
    {
        DontDestroy.Instance.PlaySomeSounds();
        if (ButtonsSelection.active)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            ButtonsSelection.SetActive(true);
            NumberPlayers.SetActive(false);
        }
    }

    public void OnePlayer()
    {
        DontDestroy.Instance.PlaySomeSounds();
        NumPlayer = 1;
        GoPlay();
    }

    public void FourPlayer()
    {
        DontDestroy.Instance.PlaySomeSounds();
        NumPlayer = 4;
        GoPlay();
    }

    public void GoPlay()
    {
        SceneManager.LoadScene(select + NumPlayer.ToString());
    }
}
