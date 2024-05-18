using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainScriptPairGame : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public List<ButtonPairGame> buttons = new List<ButtonPairGame>();
    public List<ButtonPairGame> Compare = new List<ButtonPairGame>();
    public Sprite SpriteFront;
    public List<int> ints = new List<int>();
    float time = 0f;
    public GameObject win;
    float timer = 0f;
    public Text text;

    void Restart()
    {
        foreach(var but in buttons)
        {
            win.SetActive(false);
            but.CardNum = -1;
            Compare.Clear();
            but.block = false;
            //but.FlipCard(true);
            time = 0f;
            but.Finish = false;
            but.faceSide = true;
            ints.Clear();
            try
            {
                but.image.sprite = SpriteFront;
            }
            catch { Debug.Log("pizda"); }
        }
        int Pair = buttons.Count / 2;
        for (int i = 0; i < Pair; i++)
        {
            int Random1 = 0;
            do
            {
                Random1 = UnityEngine.Random.Range(0, buttons.Count);
            }
            while (buttons[Random1].CardNum != -1);
            int Random2 = 0;
            do
            {
                Random2 = UnityEngine.Random.Range(0, buttons.Count);
            }
            while (buttons[Random2].CardNum != -1 || Random1 == Random2);
            int Random3 = 0;
            do
            {
                Random3 = UnityEngine.Random.Range(0, sprites.Count/2);
            }
            while (ints.Contains(Random3));
            ints.Add(Random3);
            buttons[Random1].CardNum = i;
            buttons[Random2].CardNum = i;
            buttons[Random1].SpriteBack = sprites[Random3*2];
            buttons[Random2].SpriteBack = sprites[Random3*2+1];
            Debug.Log(Random1);
            Debug.Log(Random2);
            Debug.Log(i);
        }
    }

    void Start()
    {
        Restart();
    }

    void Sbros()
    {
        if(Compare.Count >= 2)
        {
            if (Compare[0] != Compare[1])
            {
                if (Compare[0].CardNum == Compare[1].CardNum)
                {
                    Compare[0].Finish = true;
                    Compare[1].Finish = true;
                }
                foreach (var but in buttons)
                {
                    but.block = true;
                }
                //Debug.Log(time);
                time = time + Time.deltaTime;
                if (time > 2)
                {
                    foreach (var but in buttons)
                    {
                        if (but.faceSide == false)
                        {
                            Compare.Clear();
                            but.block = false;
                            but.FlipCard(true);
                            time = 0f;
                        }
                    }
                }
            }
            else
            {
                Compare.Clear();
            }
        }
        else
        {
            foreach (var but in buttons)
            {
                but.block = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Math.Round(timer, 1).ToString() + " сек";
        Sbros();
        bool allbutfinish = true;
        foreach(var but in buttons)
        {
            if (!but.Finish)
            {
                allbutfinish = false;
                timer = timer + Time.deltaTime;
                break;
            }
        }
        if (allbutfinish)
        {
            win.SetActive(true);
        }
    }

    public void reset()
    {
        Restart();
    }
}
