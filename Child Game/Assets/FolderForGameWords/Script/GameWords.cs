using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI; 

public class GameWords : MonoBehaviour
{
    private bool StatusimageError = false;
    private int RightAnswer;
    public Image image;
    private float time = 0f;
    private bool Status = false;
    public Text text;
    public List<Button> buttons;
    public bool block = false;
    public GameObject MainText;
    public GameObject WinObject;

    private List<Words> words = new List<Words>()
    {
        new Words("�� ������ � � �� �����.", new List<string>(){"������", "�������", "�����"}),
        new Words("�� � ���������, �� ��� ���������.", new List<string>(){"������", "��������" , "������" }), 
        new Words("� ������� � � ����� ��������.", new List<string>(){"������", "����������", "�������"}),
        new Words("��� � � ����.", new List<string>(){"������", "�����", "������"}),
        new Words("������ � �����, � ����� �������.", new List<string>(){"������", "�������", "������"}),
        new Words("���� ����� ������, � � �����.", new List<string>(){ "������", "�����", "�����"}),
        new Words("�� ���� � � �����.", new List<string>(){ "�����", "�����", "������" }),
        new Words("� ���� �� � � ������ ������.", new List<string>(){ "�����", "�����", "�������"}),
        new Words("������ �����, ������ �� ��� � ", new List<string>(){ "������", "������", "�����"}),
        new Words("��� ����� �� �������� � � �� �����.", new List<string>(){ "�����", "������", "�������"}),

        new Words("������� �� ������� �����, �� � ������.", new List<string>(){"����", "�����", "�������"}),
        new Words("� �������� ���� � �������� �.", new List<string>(){"���", "�������", "�������" }),
        new Words("����� �� �������, ������� � �� �.", new List<string>(){ "��������", "��������", "����������"}),
        new Words("������ ���� ����� ����� �.", new List<string>(){ "����", "��������", "����"}),
        new Words("� ���� ����� � �� � ���.", new List<string>(){ "������", "������", "������"}),
        new Words("� ���� ����� ���� ��� �.", new List<string>(){ "�����", "������", "��������"}),
        new Words("������� �������� �� ����� �.", new List<string>(){ "���", "�����", "�������" }),
        new Words("�� ��� ������� �, ��� � ���� �������.", new List<string>(){ "���", "������", "�������"}),
        new Words("��� ����� � ����� �.", new List<string>(){ "�����", "������", "�����������"}),
        new Words("��� ���� - ��� �.", new List<string>(){ "�����", "�����", "�������"}),
    };

    public void ClickButton(int num)
    {
        if (!block)
        {
            block = true;
            if (num == RightAnswer)
            {
                text.text = text.text.Replace("�", buttons[num].GetComponentInChildren<Text>().text);
                Status = true;
            }
            else
            {
                image.gameObject.SetActive(true);
                StatusimageError = true;
            }
        }
    }

    public void GenerationWords()
    {
        block = false;
        int Random = UnityEngine.Random.Range(0, words.Count-1);
        text.text = words[Random].text;
        RightAnswer = UnityEngine.Random.Range(0, words[Random].answer.Count - 1);
        buttons[RightAnswer].GetComponentInChildren<Text>().text = words[Random].answer[0];
        List<Button> answer = new List<Button>() { buttons[0], buttons[1], buttons[2] };
        answer.Remove(buttons[RightAnswer]);
        int Random1 = UnityEngine.Random.Range(1, words[Random].answer.Count - 1);
        answer[0].GetComponentInChildren<Text>().text = words[Random].answer[Random1];
        if (Random1 == 1)
        {
            answer[1].GetComponentInChildren<Text>().text = words[Random].answer[2];
        }
        else
        {
            answer[1].GetComponentInChildren<Text>().text = words[Random].answer[1];
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GenerationWords();
        image.gameObject.SetActive(false);
        WinObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Status)
        {
            WinObject.SetActive(true);
            time = time + Time.deltaTime;
            if(time > 5f)
            {
                Status = false;
                WinObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
        if (StatusimageError) 
        {
            time = time + Time.deltaTime;
            MainText.SetActive(false);
            if (time > 5f)
            {
                MainText.SetActive(true);
                StatusimageError = false;
                image.gameObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
    }

    class Words
    {
        public string text;
        public List<string> answer;

        public Words(string txt,List<string> answers)
        {
            text = txt;
            answer = answers;
        }
    }
}
