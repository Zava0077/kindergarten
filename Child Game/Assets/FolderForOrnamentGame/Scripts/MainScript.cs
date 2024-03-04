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

    private void RestartGame()
    {
        //int random = UnityEngine.Random.Range(0, 1);
        int random = 1;
        random = random * 9;
        foreach (var slot in selectOrnaments)
        {
            slot.CodeOrnament = 0;
        }
        code = Enumerable.Range(1, 9).OrderBy(x => UnityEngine.Random.value).ToList();
        Debug.Log(Convert.ToString(code[0]) + Convert.ToString(code[1]) + Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]) + Convert.ToString(code[6]) + Convert.ToString(code[7]));
        MainOrnament.sprite = Sprites[random];
        Debug.Log(Sprites.Count);
        for (int i = 0; i < selectOrnaments.Count; i++)
        {
            selectOrnaments[i].CodeOrnament = code[i];
            if (code[i] == 9)
            {
                selectOrnaments[i].image.sprite = Sprites[UnityEngine.Random.Range(0,Sprites.Count)];
            }
            else
            {
                selectOrnaments[i].image.sprite = Sprites[code[i] + random];
            }

        }
    }

    void Start()
    {
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
            Debug.Log("Победа");
        }
    }
}
