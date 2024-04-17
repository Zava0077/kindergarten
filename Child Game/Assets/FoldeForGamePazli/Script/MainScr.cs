using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<Select> selects = new List<Select>();
    List<int> code = new List<int>();
    List<int> check = new List<int>();
    public Image Hearth;
    public List<Sprite> sprites = new List<Sprite>();
    float time = 0f;

    private void RestartGame()
    {
        foreach (var slot in selects)
        {
            slot.CodePazel = 0;
            slot.transform.position = slot.pos;
        }
        foreach (var slot in slots)
        {
            slot.CodeSlot = 0;
        }
        int random = UnityEngine.Random.Range(0, sprites.Count / 5);
        //int random = 0;
        random = random * 5;
        code = Enumerable.Range(1, 4).OrderBy(x => UnityEngine.Random.value).ToList();
        Hearth.sprite = sprites[random];
        //Debug.Log(Sprites.Count);
        for (int i = 0; i < selects.Count; i++)
        {
            selects[i].CodePazel = code[i];
            selects[i].image.sprite = sprites[code[i] + random];

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        check.Clear();
        foreach (var slot in slots)
        {
            check.Add(slot.CodeSlot);
        }
        Debug.Log(check[0] + "" + check[1] + "" + check[2] + "" + check[3]);
        if (check.SequenceEqual<int>(new List<int> { 1, 2, 3, 4 }))
        {
            time = time + Time.deltaTime;
            Debug.Log(time);
            if (time >= 5f)
            {
                time = 0f;
                RestartGame();
            }
        }
    }
}

