using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class MainScript : MonoBehaviour
{
    public List<SlotOrnament> slotOrnaments = new List<SlotOrnament>();
    public List<SelectOrnament> selectOrnaments = new List<SelectOrnament>();
    List<int> code = new List<int>();
    List<int> check = new List<int>();
    public Image MainOrnament;
    public List<Sprite> Sprites = new List<Sprite>();
    public List<Sprite> FlagSprites = new List<Sprite>();
    public GameObject WinObject;
    float time = 0f;
    public GameObject Game;
    AudioSource Audio;
    float timer = 0f;
    public Text timerText;
    public Text FlagText;
    public Image Flag;
    public enum Flags
    {
        Russia,
        Tatarstan,
        Poland,
        Israel,
        Belarus
    };
    Flags Flagi;


    public void RestartGame()
    {
        timer = 0f;
        WinObject.SetActive(false);
        foreach (var slot in selectOrnaments)
        {
            slot.CodeOrnament = 0;
            slot.transform.localPosition = slot.pos;
        }
        foreach (var slot in slotOrnaments)
        {
            slot.CodeSlot = 0;
        }
        int random = UnityEngine.Random.Range(0, Sprites.Count / 9);
        #region Флаги
        switch (random) 
        {
            case 0:
                Flagi = Flags.Russia;
                break;
            case 1:
                Flagi = Flags.Russia;
                break;
            case 2:
                Flagi = Flags.Russia;
                break;
            case 3:
                Flagi = Flags.Tatarstan;
                break;
            case 4:
                Flagi = Flags.Tatarstan;
                break;
            case 5:
                Flagi = Flags.Poland;
                break;
            case 6:
                Flagi = Flags.Poland;
                break;
        }
        #endregion
        random = random * 9;
        code = Enumerable.Range(1, 9).OrderBy(x => UnityEngine.Random.value).ToList();
        //Debug.Log(Convert.ToString(code[0]) + Convert.ToString(code[1]) + Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]) + Convert.ToString(code[6]) + Convert.ToString(code[7]));
        MainOrnament.sprite = Sprites[random];
        //Debug.Log(Sprites.Count);
        List<Sprite> sprites = new List<Sprite>();
        sprites.Clear();
        for (int i = 0; i < selectOrnaments.Count; i++)
        {
            selectOrnaments[i].CodeOrnament = code[i];
            if (code[i] == 9)
            {
                int rnd;
                do
                {
                    rnd = UnityEngine.Random.Range(0, Sprites.Count);
                    selectOrnaments[i].image.sprite = Sprites[rnd];
                    Debug.Log(rnd);
                }
                while (rnd % 9 == 0 || sprites.Contains(selectOrnaments[i].image.sprite));
            }
            else
            {
                selectOrnaments[i].image.sprite = Sprites[code[i] + random];
            }
            sprites.Add(selectOrnaments[i].image.sprite);
        }
    }

    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        //таймер
        if(WinObject.activeSelf == false)
        {
            timer = timer + Time.deltaTime;
            timerText.text = Math.Round(timer, 1).ToString() + " сек";
        }
        //Проверка на победу
        check.Clear();
        foreach(var slot in slotOrnaments)
        {
            check.Add(slot.CodeSlot);
        }
        //Победа
        if(check.SequenceEqual<int>(new List<int> { 1,2,3,4,5,6,7,8 }))
        {
            #region Флаги
            switch ((int)Flagi)
            {
                case 0:
                    FlagText.text = "Молодец! Ты собрал Русский орнамент";
                    break;
                case 1:
                    FlagText.text = "Молодец! Ты собрал Татарский орнамент";
                    break;
                case 2:
                    FlagText.text = "Молодец! Ты собрал Польский орнамент";
                    break;
                case 3:
                    FlagText.text = "Молодец! Ты собрал Израильский орнамент";
                    break;
                case 4:
                    FlagText.text = "Молодец! Ты собрал Белорусский орнамент";
                    break;
            }
            #endregion
            Flag.sprite = FlagSprites[(int)Flagi];
            WinObject.SetActive(true);
            Audio.Play();
        }
    }
}
