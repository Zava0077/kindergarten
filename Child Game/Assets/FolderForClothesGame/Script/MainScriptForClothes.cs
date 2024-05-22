using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using System.Threading;
using UnityEngine.U2D;

public class MainScriptForClothes : MonoBehaviour
{
    public List<ButtonClothes> buttons = new List<ButtonClothes>();
    public List<Sprite> Sprites = new List<Sprite>();
    public List<Image> Human = new List<Image>();
    public List<Sprite> RightVer = new List<Sprite>(3);
    public List<Sprite> Base = new List<Sprite>();
    public Text text;
    private List<int> code;
    public Image TaskImage;
    public Text TaskText;
    public GameObject TaskPanel;
    float time = 0f;
    public GameObject WinPanel;
    public Text TimerText;
    public Text TextBackground;

    private Dictionary<string, (string taskText, string backgroundText)> textDictionary = new Dictionary<string, (string, string)>()
    {
        { "Russia", ("Необходимо одеть человека в русский национальный костюм", "Нужно одеть в русский костюм") },
        { "Tatar", ("Необходимо одеть человека в татарский национальный костюм", "Нужно одеть в татарский костюм") },
        { "Belorus", ("Необходимо одеть человека в белорусский национальный костюм", "Нужно одеть в белорусский костюм") },
        { "Ukrain", ("Необходимо одеть человека в украинский национальный костюм", "Нужно одеть в украинский костюм") },
        { "Kirgis", ("Необходимо одеть человека в киргизский национальный костюм", "Нужно одеть в киргизский костюм") },
        { "Azerbaijani", ("Необходимо одеть человека в азербайджанский национальный костюм", "Нужно одеть в азербайджанский костюм") },
        { "Kazah", ("Необходимо одеть человека в казахский национальный костюм", "Нужно одеть в казахский костюм") },
        { "Burat", ("Необходимо одеть человека в бурятский национальный костюм", "Нужно одеть в бурятский костюм") },
        { "German", ("Необходимо одеть человека в немецкий национальный костюм", "Нужно одеть в немецкий костюм") },
        { "Arman", ("Необходимо одеть человека в армянский национальный костюм", "Нужно одеть в армянский костюм") },
        { "Tadjick", ("Необходимо одеть человека в таджикский национальный костюм", "Нужно одеть в таджикский костюм") },
        { "Chuvash", ("Необходимо одеть человека в чувашский национальный костюм","Нужно одеть в чувашский костюм") }
    };

    void Start()
    {
        RestartGame();
    }

    public void CloseTaskPanel()
    {
        TaskPanel.SetActive(false);
    }
    public void OpenTaskPanel()
    {
        TaskPanel.SetActive(true);
    }


    public void RestartGame()
    {
        TaskPanel.SetActive(true);
        time = 0f;
        WinPanel.SetActive(false);
        for(int i = 0; i < Base.Count; i++)
        {
            Human[i].sprite = Base[i];
        }
        foreach(var button in buttons)
        {
            button.status = ButtonClothes.StatusClothes.nothing;
        }
        int random = UnityEngine.Random.Range(0, Sprites.Count / 4) * 4;
        foreach (var entry in textDictionary)
        {
            if (Sprites[random].name.Contains(entry.Key))
            {
                TaskText.text = entry.Value.taskText;
                TextBackground.text = entry.Value.backgroundText;
            }
        }
        TaskImage.sprite = Sprites[random];
        code = Enumerable.Range(1, 3).OrderBy(x => UnityEngine.Random.value).ToList();
        for (int i = 0; i < RightVer.Count; i++)
        {
            RightVer[i] = Sprites[i+random+1];
            Debug.Log(RightVer[i].name);
        }
        List<int> Answers = new List<int>();
        while (Answers.Count < 3)
        {
            int randomnumber = UnityEngine.Random.Range(0,7);
            if (!Answers.Contains(randomnumber))
            {
                Answers.Add(randomnumber);
            }
        }
        for (int i = 0; i < Answers.Count; i++)
        {
            buttons[Answers[i]].Image.sprite = RightVer[i];
            buttons[Answers[i]].status = (ButtonClothes.StatusClothes)i;
        }
        List<Sprite> otherButtons = new List<Sprite>();
        foreach (var but in buttons)
        {
            if(but.status == ButtonClothes.StatusClothes.nothing)
            {
                do
                {
                    otherButtons.Clear();
                    foreach (var button in buttons)
                    {
                        otherButtons.Add(button.Image.sprite);
                    }
                    int ran = UnityEngine.Random.Range(0, Sprites.Count / 4) * 4;
                    int ran2 = UnityEngine.Random.Range(1, 3);
                    but.Image.sprite = Sprites[ran + ran2];
                    but.status = (ButtonClothes.StatusClothes)ran2-1;
                }
                while (otherButtons.Contains(but.Image.sprite));
            }
        }
        Debug.Log(otherButtons.Count);
    }

    // Update is called once per frame
    void Update()
    {
        int Win = 0;
        for(int i = 0; i < Human.Count; i++)
        {
            if (Human[i].sprite == RightVer[i])
            {
                Win++;
            }
        }
        if (Win==3)
        {
            TimerText.text = Math.Round(time, 1).ToString() + " сек";
            WinPanel.SetActive(true);
        }
        else
        {
            time = time + Time.deltaTime;
            WinPanel.SetActive(false);
        }
    }
}
