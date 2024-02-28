using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI; 

public class GameWords : MonoBehaviour
{
    private bool StatusimageError = false;
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
            StatusimageError = true;
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
            StatusimageError = true;
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
            StatusimageError = true;
        }
    }

    public void GenerationWords()
    {
        //int random = Random.Range(0, 9);
        int random = 8;
        switch (random)
        {
            case 0:
                words[0] = "�� ������ � ";
                words[1] = "........ ";
                words[2] = "�� �����.";
                int RandomButton = Random.Range(0, 4);
                switch (RandomButton)
                {
                    case 1:
                        rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "�������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 2:
                        rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 3:
                        rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }
                break;
            case 1:
                words[0] = "�� ";
                words[1] = "........ ";
                words[2] = "���������, �� ��� ���������.";
                int RandomButton1 = Random.Range(0, 4);
                switch(RandomButton1)
                {
                    case 1: rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "��������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 2: rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "��������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 3: rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "��������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }
                break;
            case 2:
                words[0] = "� ������� ";
                words[1] = "........ ";
                words[2] = "� ����� ��������.";
                int RandomButton2 = Random.Range(0, 4);
                switch (RandomButton2) 
                {
                    case 1:rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "����������";
                        button3.GetComponentInChildren<Text>().text = "�������";
                        break;
                    case 2:rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "����������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�������";
                        break;
                    case 3:rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�������";
                        button2.GetComponentInChildren<Text>().text = "����������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }
                break;
            case 3:
                words[0] = "��� ";
                words[1] = "........";
                words[2] = " - ����.";
                int RandomButton3 = Random.Range(0, 4);
                switch(RandomButton3)
                {
                    case 1:rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 2:rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 3:rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }

                break;
            case 4:
                words[0] = "������ ";
                words[1] = "........ ";
                words[2] = "�����, � ����� �������.";
                int RandomButton4 = Random.Range(0, 4);
                switch (RandomButton4)
                {
                    case 1:rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "�������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 2: rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 3: rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }
                break;
            case 5:
                words[0] = "���� ����� ������, � ";
                words[1] = "........";
                words[2] = "�����.";
                int RandomButton5 = Random.Range(0, 4);
                switch (RandomButton5)
                {
                    case 1: rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 2:rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 3: rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                }
                break;
            case 6:
                words[0] = "�� ���� �";
                words[1] = "........ ";
                words[2] = "�����.";
                int RandomButton6 = Random.Range(0, 4);
                switch (RandomButton6)
                {
                    case 1:
                        rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 2:
                        rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "������";
                        break;
                    case 3:
                        rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                }
                break;
            case 7:
                words[0] = "� ���� ��";
                words[1] = "........";
                words[2] = " - ������ ������";
                int RandomButton7 = Random.Range(0, 4);
                switch (RandomButton7)
                {
                    case 1:
                        rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "�������";
                        break;
                    case 2:
                        rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "�������";
                        break;
                    case 3:
                        rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "�����";
                        button2.GetComponentInChildren<Text>().text = "�������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                }
                break;
            case 8:
                words[0] = "������ �����,";
                words[1] = " ������ �� ���";
                words[2] = "........";
                int RandomButton8 = Random.Range(0, 4);
                switch (RandomButton8)
                {
                    case 1:
                        rightButton = 0;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 2:
                        rightButton = 1;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "������";
                        button3.GetComponentInChildren<Text>().text = "�����";
                        break;
                    case 3:
                        rightButton = 2;
                        button1.GetComponentInChildren<Text>().text = "������";
                        button2.GetComponentInChildren<Text>().text = "�����";
                        button3.GetComponentInChildren<Text>().text = "������";
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
