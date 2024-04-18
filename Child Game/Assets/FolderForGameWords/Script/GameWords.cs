using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI; 

public class GameWords : MonoBehaviour
{
    private bool[] threerightbutton = new bool[3];
    private bool StatusimageError = false;
    public Image image;
    private float time = 0f;
    private bool Status = false;
    private string[] words = new string[3];
    public Text text;
    public Button button1;
    public Button button2;
    public Button button3;
    public void ClickButton1()
    {
        if (threerightbutton[0])
        {
            words[1] = button1.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusimageError = true;
        }
    }
    public void ClickButton2()
    {
        if (threerightbutton[1])
        {
            words[1] = button2.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusimageError = true;
        }
    }
    public void ClickButton3()
    {
        if (threerightbutton[2])
        {
            words[1] = button3.GetComponentInChildren<Text>().text + " ";
            Status = true;
        }
        else
        {
            image.gameObject.SetActive(true);
            StatusimageError = true;
        }
    }

    public void GenerationWords()
    {
        for (int i = 0; i < threerightbutton.Length; i++) 
        {
            threerightbutton[i] = false;
        }

        int random = Random.Range(0, 9);
        switch (random)
        {
            case 0:
                words[0] = "За словом в ";
                words[1] = "........ ";
                words[2] = "не лезут.";
                int RandomButton = Random.Range(1, 3);
                switch (RandomButton)
                {
                    case 1:
                        threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "карман";
                        button2.GetComponentInChildren<Text>().text = "чемодан";
                        button3.GetComponentInChildren<Text>().text = "сумку";
                        break;
                    case 2:
                        threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "чемодан";
                        button2.GetComponentInChildren<Text>().text = "карман";
                        button3.GetComponentInChildren<Text>().text = "сумку";
                        break;
                    case 3:
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "сумка";
                        button2.GetComponentInChildren<Text>().text = "чемодан";
                        button3.GetComponentInChildren<Text>().text = "карман";
                        break;
                }
                break;
            case 1:
                words[0] = "По ";
                words[1] = "........ ";
                words[2] = "встречают, по уму провожают.";
                int RandomButton1 = Random.Range(1, 3);
                switch(RandomButton1)
                {
                    case 1: threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "одежке";
                        button2.GetComponentInChildren<Text>().text = "прическе";
                        button3.GetComponentInChildren<Text>().text = "пальто";
                        break;
                    case 2: threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "прическе";
                        button2.GetComponentInChildren<Text>().text = "одежке";
                        button3.GetComponentInChildren<Text>().text = "пальто";
                        break;
                    case 3: threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "прическе";
                        button2.GetComponentInChildren<Text>().text = "пальто";
                        button3.GetComponentInChildren<Text>().text = "одежке";
                        break;
                }
                break;
            case 2:
                words[0] = "В хорошем ";
                words[1] = "........ ";
                words[2] = "и пенек красивый.";
                int RandomButton2 = Random.Range(1, 3);
                switch (RandomButton2) 
                {
                    case 1:threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "платье";
                        button2.GetComponentInChildren<Text>().text = "настроении";
                        button3.GetComponentInChildren<Text>().text = "камзоле";
                        break;
                    case 2:threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "настроении";
                        button2.GetComponentInChildren<Text>().text = "платье";
                        button3.GetComponentInChildren<Text>().text = "камзоле";
                        break;
                    case 3:threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "камзоле";
                        button2.GetComponentInChildren<Text>().text = "настроении";
                        button3.GetComponentInChildren<Text>().text = "платье";
                        break;
                }
                break;
            case 3:
                words[0] = "Два ";
                words[1] = "........ ";
                words[2] = "- пара.";
                int RandomButton3 = Random.Range(1, 3);
                switch(RandomButton3)
                {
                    case 1:threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "сапога";
                        button2.GetComponentInChildren<Text>().text = "брата";
                        button3.GetComponentInChildren<Text>().text = "солнца";
                        break;
                    case 2:threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "брата";
                        button2.GetComponentInChildren<Text>().text = "сапога";
                        button3.GetComponentInChildren<Text>().text = "солнца";
                        break;
                    case 3:threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "брата";
                        button2.GetComponentInChildren<Text>().text = "солнца";
                        button3.GetComponentInChildren<Text>().text = "сапога";
                        break;
                }

                break;
            case 4:
                words[0] = "Береги ";
                words[1] = "........ ";
                words[2] = "снову, а честь смолоду.";
                int RandomButton4 = Random.Range(1, 3);
                switch (RandomButton4)
                {
                    case 1:threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "платье";
                        button2.GetComponentInChildren<Text>().text = "сарафан";
                        button3.GetComponentInChildren<Text>().text = "сапоги";
                        break;
                    case 2: threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "сарафан";
                        button2.GetComponentInChildren<Text>().text = "платье";
                        button3.GetComponentInChildren<Text>().text = "сапоги";
                        break;
                    case 3: threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "сарафан";
                        button2.GetComponentInChildren<Text>().text = "сапоги";
                        button3.GetComponentInChildren<Text>().text = "платье";
                        break;
                }
                break;
            case 5:
                words[0] = "Друг лучше старый, а ";
                words[1] = "........ ";
                words[2] = "новая.";
                int RandomButton5 = Random.Range(1, 3);
                switch (RandomButton5)
                {
                    case 1: 
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "одежка";
                        button2.GetComponentInChildren<Text>().text = "сумка";
                        button3.GetComponentInChildren<Text>().text = "шапка";
                        break;
                    case 2:
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "сумка";
                        button2.GetComponentInChildren<Text>().text = "одежка";
                        button3.GetComponentInChildren<Text>().text = "шапка";
                        break;
                    case 3:
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "сумка";
                        button2.GetComponentInChildren<Text>().text = "шапка";
                        button3.GetComponentInChildren<Text>().text = "одежка";
                        break;
                }
                break;
            case 6:
                words[0] = "На воре и ";
                words[1] = "........ ";
                words[2] = "горит.";
                int RandomButton6 = Random.Range(1, 3);
                switch (RandomButton6)
                {
                    case 1:
                        threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "шапка";
                        button2.GetComponentInChildren<Text>().text = "тулуп";
                        button3.GetComponentInChildren<Text>().text = "звезда";
                        break;
                    case 2:
                        threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "тулуп";
                        button2.GetComponentInChildren<Text>().text = "шапка";
                        button3.GetComponentInChildren<Text>().text = "звезда";
                        break;
                    case 3:
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "тулуп";
                        button2.GetComponentInChildren<Text>().text = "звезда";
                        button3.GetComponentInChildren<Text>().text = "шапка";
                        break;
                }
                break;
            case 7:
                words[0] = "С миру по ";
                words[1] = "........";
                words[2] = " - голому рубаха";
                int RandomButton7 = Random.Range(1, 3);
                switch (RandomButton7)
                {
                    case 1:
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "нитке";
                        button2.GetComponentInChildren<Text>().text = "рублю";
                        button3.GetComponentInChildren<Text>().text = "карману";
                        break;
                    case 2:
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "рублю";
                        button2.GetComponentInChildren<Text>().text = "нитке";
                        button3.GetComponentInChildren<Text>().text = "карману";
                        break;
                    case 3:
                        threerightbutton[0] = true;
                        threerightbutton[1] = true;
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "рублю";
                        button2.GetComponentInChildren<Text>().text = "карману";
                        button3.GetComponentInChildren<Text>().text = "нитке";
                        break;
                }
                break;
            case 8:
                words[0] = "Какова пряха, такова на ней ";
                words[1] = "........";
                words[2] = " ";
                int RandomButton8 = Random.Range(1, 3);
                switch (RandomButton8)
                {
                    case 1:
                        threerightbutton[0] = true;
                        button1.GetComponentInChildren<Text>().text = "рубаха";
                        button2.GetComponentInChildren<Text>().text = "пижама";
                        button3.GetComponentInChildren<Text>().text = "сумка";
                        break;
                    case 2:
                        threerightbutton[1] = true;
                        button1.GetComponentInChildren<Text>().text = "пимажа";
                        button2.GetComponentInChildren<Text>().text = "рубаха";
                        button3.GetComponentInChildren<Text>().text = "сумка";
                        break;
                    case 3:
                        threerightbutton[2] = true;
                        button1.GetComponentInChildren<Text>().text = "пижама";
                        button2.GetComponentInChildren<Text>().text = "сумка";
                        button3.GetComponentInChildren<Text>().text = "рубаха";
                        break;
                }
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
        if (StatusimageError) 
        {
            time = time + Time.deltaTime;
            if(time > 5f)
            {
                StatusimageError = false;
                image.gameObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
    }
}
