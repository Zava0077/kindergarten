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
        //SceneManager.LoadScene("OrnamentGame");
        ButtonsSelection.SetActive(false);
        select = "OrnamentGame";
        NumberPlayers.SetActive(true);
    }

    public void GameWords()
    {
        //SceneManager.LoadScene("WordsGame");
        ButtonsSelection.SetActive(false);
        select = "WordsGame";
        NumberPlayers.SetActive(true);
    }
    
    public void ClothesGame()
    {
        //SceneManager.LoadScene("clothes");
        ButtonsSelection.SetActive(false);
        select = "clothes";
        NumberPlayers.SetActive(true);
    }

    public void PuzzleGame()
    {
        //SceneManager.LoadScene("GamePazli");
        ButtonsSelection.SetActive(false);
        select = "GamePazli";
        NumberPlayers.SetActive(true);
    }
    
    public void PairGame()
    {
        //SceneManager.LoadScene("Pair");
        ButtonsSelection.SetActive(false);
        select = "Pair";
        NumberPlayers.SetActive(true);
    }

    public void Back()
    {
        if(ButtonsSelection.active)
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
        NumPlayer = 1;
        GoPlay();
    }

    public void FourPlayer()
    {
        NumPlayer = 4;
        GoPlay();
    }

    public void GoPlay()
    {
        SceneManager.LoadScene(select + NumPlayer.ToString());
    }
}
