using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectionButtons : MonoBehaviour
{

    public void OrnamentGame()
    {
        SceneManager.LoadScene("OrnamentGame");
    }

    public void GameWords()
    {
        SceneManager.LoadScene("WordsGame");
    }
    
    public void ClothesGame()
    {
        SceneManager.LoadScene("clothes");
    }
}
