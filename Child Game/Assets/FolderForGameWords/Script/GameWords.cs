using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI; 

public class GameWords : MonoBehaviour
{
    private bool StatusSC = false;
    public Image image;
    private float time = 0f;
    private bool Status = false;
    private string[] words = new string[3];
    private int rightButton;
    public Text text;
    public Button button1;
    public Button button2;
    public Button button3;
    public void ClickButton1()
    {
        if (rightButton == 0)
        {
            words[1] = button1.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusSC = true;
        }
    }
    public void ClickButton2()
    {
        if (rightButton == 1)
        {
            words[1] = button2.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusSC = true;
        }
    }
    public void ClickButton3()
    {
        if (rightButton == 2)
        {
            words[1] = button3.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusSC = true;
        }
    }

    public void GenerationWords()
    {
        //int random = Random.Range(0, 9);
        int random = 0;
        switch (random)
        {
            case 0:
                words[0] = "За словом в ";
                words[1] = "...... ";
                words[2] = "не лезут";
                int RandomButton = Random.Range(0, 4);
                switch (RandomButton)
                {
                    case 1:
                        rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "карман";
                        button2.GetComponentInChildren<Text>().text = "чемодан";
                        button3.GetComponentInChildren<Text>().text = "сумку";
                        break;
                    case 2:
                        rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "чемодан";
                        button2.GetComponentInChildren<Text>().text = "карман";
                        button3.GetComponentInChildren<Text>().text = "сумку";
                        break;
                    case 3:
                        rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "сумка";
                        button2.GetComponentInChildren<Text>().text = "чемодан";
                        button3.GetComponentInChildren<Text>().text = "карман";
                        break;
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerationWords();
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = words[0] + words[1] + words[2];
        if (Status)
        {
            time = time + Time.deltaTime;
            if(time > 5f)
            {
                Status = false;
                GenerationWords();
                time = 0f;
            }
        }
        if (StatusSC) 
        {
            time = time + Time.deltaTime;
            if(time > 5f)
            {
                StatusSC = false;
                image.gameObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
    }
}
