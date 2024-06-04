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
    private AudioSource audioSource;
    public List<AudioClip> clipList;

    void Awake()
    {
        Image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        int random = UnityEngine.Random.Range(0, clipList.Count);
        audioSource.clip = clipList[random];
        audioSource.Play();
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
