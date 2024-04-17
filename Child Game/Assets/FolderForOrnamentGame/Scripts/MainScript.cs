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
    public List<Sprite> Flags = new List<Sprite>();
    public GameObject WinObject;
    float time = 0f;
    public GameObject Game;
    AudioSource Audio;

    public void RestartGame()
    {
        Audio.Play();
        WinObject.SetActive(false);
        foreach (var slot in selectOrnaments)
        {
            slot.CodeOrnament = 0;
            slot.transform.position = slot.pos;
        }
        foreach (var slot in slotOrnaments)
        {
            slot.CodeSlot = 0;
        }
        int random = UnityEngine.Random.Range(0, Sprites.Count / 9);
        //int random = 2;
        random = random * 9;
        code = Enumerable.Range(1, 9).OrderBy(x => UnityEngine.Random.value).ToList();
        Debug.Log(Convert.ToString(code[0]) + Convert.ToString(code[1]) + Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]) + Convert.ToString(code[6]) + Convert.ToString(code[7]));
        MainOrnament.sprite = Sprites[random];
        //Debug.Log(Sprites.Count);
        for (int i = 0; i < selectOrnaments.Count; i++)
        {
            selectOrnaments[i].CodeOrnament = code[i];
            if (code[i] == 9)
            {
                int rnd;
                do
                {
                    rnd = UnityEngine.Random.Range(0, Sprites.Count);
                    Debug.Log(rnd);
                }
                while (rnd % 9 == 0);
                selectOrnaments[i].image.sprite = Sprites[rnd];
            }
            else
            {
                selectOrnaments[i].image.sprite = Sprites[code[i] + random];
            }

        }
    }

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        check.Clear();
        foreach(var slot in slotOrnaments)
        {
            check.Add(slot.CodeSlot);
        }
        if(check.SequenceEqual<int>(new List<int> { 1,2,3,4,5,6,7,8 }))
        {
            WinObject.SetActive(true);
            Audio.Play();
            /*
            time = time + Time.deltaTime;
            Debug.Log(time);
            if(time >= 3f)
            {
                Audio.Play();
                time = 0f;
                RestartGame();
            }
            */
        }
    }
}
