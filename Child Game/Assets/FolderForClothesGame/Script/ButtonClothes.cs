using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClothes : MonoBehaviour
{
    public enum StatusClothes
    {
        head,
        body,
        boots,
        nothing
    }
    public StatusClothes status;
    public Image Image;
    public MainScriptForClothes main;

    void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void Click()
    {
        switch (status)
        {
            case StatusClothes.head:
                main.Human[0].sprite = Image.sprite;
                break;
            case StatusClothes.body:
                main.Human[1].sprite = Image.sprite;
                break;
            case StatusClothes.boots:
                main.Human[2].sprite = Image.sprite;
                break;
        }
    }
}
