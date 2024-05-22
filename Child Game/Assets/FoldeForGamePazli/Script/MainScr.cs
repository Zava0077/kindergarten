using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<Select> selects = new List<Select>();
    public List<Select> Spys = new List<Select>();
    List<int> code = new List<int>();
    List<int> check = new List<int>();
    public Image Hearth;
    public List<Sprite> sprites = new List<Sprite>();
    float time = 0f;
    public GameObject Game;
    public GameObject Win;
    public Text TimerText;
    float timer = 0f;

    private void RestartGame()
    {
        //�����
        Win.SetActive(false);
        timer = 0f;
        foreach (var slot in selects)
        {
            slot.CodePazel = 0;
            slot.transform.localPosition = slot.pos;
        }
        foreach (var slot in slots)
        {
            slot.CodeSlot = 0;
        }
        //�������� ��������� ����
        int random = UnityEngine.Random.Range(0, sprites.Count / 5);
        random = random * 5;
        //���������� ��� ��� ����������� ������
        code = Enumerable.Range(1, 4).OrderBy(x => UnityEngine.Random.value).ToList();
        //������ ������ � ������������ �������
        Hearth.sprite = sprites[random];
        //�������� ������������ �����
        for (int i = 0; i < selects.Count; i++)
        {
            selects[i].CodePazel = code[i];
            selects[i].image.sprite = sprites[code[i] + random];

        }
        //���������� ��������� �����
        List<Sprite> sprites2 = new List<Sprite>();
        foreach (var select in selects)
        {
            sprites2.Add(select.image.sprite);
        }
        foreach(var spy in Spys)
        {
            int rand = 0;
            do
            {
                do
                {
                    rand = UnityEngine.Random.Range(0, sprites.Count); 
                } while (rand % 5 == 0); 
                spy.image.sprite = sprites[rand];
            }
            while (sprites2.Contains(spy.image.sprite) || Spys[0].image.sprite == Spys[1].image.sprite);
        }
    }
    void Start()
    {
        //��� ������ ���� ������������� ����
        RestartGame();
    }
    void Update()
    {
        //��������� ��� ��� ����������� ������
        check.Clear();
        foreach (var slot in slots)
        {
            check.Add(slot.CodeSlot);
        }
        //���� ����� ������� ��������� ��
        if (check.SequenceEqual<int>(new List<int> { 1, 2, 3, 4 }))
        {
            Debug.Log(time);
            if (time >= 1f)
            {
                Win.SetActive(true);
                TimerText.text = Math.Round(timer, 1).ToString() + " ���";
            }
            else
            {
                time = time + Time.deltaTime;
            }
        }
        else
        {
            timer = timer + Time.deltaTime;
        }
    }
    public void Restart()
    {
        RestartGame();
    }
}

