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

    private void RestartGame()
    {
        foreach (var slot in selectOrnaments)
        {
            slot.CodeOrnament = 0;
        }
        code = Enumerable.Range(1, 8).OrderBy(x => UnityEngine.Random.value).ToList();
        foreach(var slot in code)
        {
            Debug.Log(slot);
        }
        for (int i = 0; i < selectOrnaments.Count; i++)
        {
            if(i < 8)
            {
                selectOrnaments[i].CodeOrnament = code[i];
            }
            else
            {
                selectOrnaments[i].CodeOrnament = 9;
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
