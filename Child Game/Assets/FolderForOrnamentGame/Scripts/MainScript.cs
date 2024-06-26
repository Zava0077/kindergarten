using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;


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
    public GameObject Select;
    bool Helping = false;
    bool _audioPlaying;
    public enum Flags
    {
        Russia,
        Tatarstan,
        Poland,
        Israel,
        Belarus
    };
    Flags Flagi;


    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Help()
    {
        DontDestroy.Instance.PlaySomeSounds();
        if (Helping == true)
        {
            Helping = false;
        }
        else
        {
            Helping = true;
        }
    }

    public void SelectOrnament()
    {
        DontDestroy.Instance.PlaySomeSounds();
        if (Select.activeSelf == true)
        {
            Select.SetActive(false);
        }
        else
        {
            Select.SetActive(true);
        }
    }


    public void RestartGame(int chosenum)
    {
        if(chosenum != -2)
        {
            DontDestroy.Instance.PlaySomeSounds();
        }
        _audioPlaying = false;
        foreach (var slot in slotOrnaments)
        {
            //slot.Status.visible = false;
        }
        Select.SetActive(false);
        bool chose;
        if (chosenum <= -1)
        {
            chose = false;
        }
        else { chose = true; }
        timer = 0f;
        WinObject.SetActive(false);
        foreach (var select in selectOrnaments)
        {
            select.CodeOrnament = 0;
            select.transform.localPosition = select.pos;
            select.currentSlot = null;
        }
        foreach (var slot in slotOrnaments)
        {
            slot.CodeSlot = 0;
        }
        //�������� ���� ����� ������� ���������
        if (chose)
        {
            #region �����
            switch (chosenum)
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
            chosenum = chosenum * 9;
            code = Enumerable.Range(1, 9).OrderBy(x => UnityEngine.Random.value).ToList();
            MainOrnament.sprite = Sprites[chosenum];
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
                    while (rnd % 9 == 0 || (rnd >= chosenum && rnd <= chosenum + 9));
                    sprites.Add(selectOrnaments[i].image.sprite);
                }
                else
                {
                    selectOrnaments[i].image.sprite = Sprites[code[i] + chosenum];
                    sprites.Add(selectOrnaments[i].image.sprite);
                }
            }
            Debug.Log("" + sprites.Count);
        }
        //�������� ���� ���� ��������� ���������� ��������
        else
        {
            int random = UnityEngine.Random.Range(0, Sprites.Count / 9);
            #region �����
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
                    while (rnd % 9 == 0 || (rnd >= random && rnd <= random + 9));
                    sprites.Add(selectOrnaments[i].image.sprite);
                }
                else
                {
                    selectOrnaments[i].image.sprite = Sprites[code[i] + random];
                    sprites.Add(selectOrnaments[i].image.sprite);
                }
            }
            Debug.Log(sprites.Count);
        }
    }

    void Start()
    {
        RestartGame(-2);
    }

    // Update is called once per frame
    void Update()
    {
        //������
        if(WinObject.activeSelf == false)
        {
            timer = timer + Time.deltaTime;
            timerText.text = Math.Round(timer, 1).ToString() + " ���";
        }
        //�������� �� ������
        check.Clear();
        foreach(var slot in slotOrnaments)
        {
            check.Add(slot.CodeSlot);
        }
        //������
        if(check.SequenceEqual<int>(new List<int> { 1,2,3,4,5,6,7,8 }))
        {
            #region �����
            switch ((int)Flagi)
            {
                case 0:
                    FlagText.text = "�������! �� ������ ������� ��������";
                    break;
                case 1:
                    FlagText.text = "�������! �� ������ ��������� ��������";
                    break;
                case 2:
                    FlagText.text = "�������! �� ������ �������� ��������";
                    break;
                case 3:
                    FlagText.text = "�������! �� ������ ����������� ��������";
                    break;
                case 4:
                    FlagText.text = "�������! �� ������ ����������� ��������";
                    break;
            }
            #endregion
            Flag.sprite = FlagSprites[(int)Flagi];
            if(_audioPlaying == false)
            {
                Audio.Play();
                _audioPlaying = true;
            }
            WinObject.SetActive(true);
        }
        //���������
        else if(Helping == true)
        {
            foreach(var slot in slotOrnaments)
            {
                slot.Status.SetActive(true);
            }
            for(int i = 0;i < slotOrnaments.Count; i++)
            {
                if (slotOrnaments[i].CodeSlot != i + 1)
                {
                    //�������
                    slotOrnaments[i].answer = false;
                }
                else
                {
                    //�����
                    slotOrnaments[i].answer = true;
                }
            }
        }
        else
        {
            foreach (var slot in slotOrnaments)
            {
                slot.Status.SetActive(false);
            }
        }
    }
}
