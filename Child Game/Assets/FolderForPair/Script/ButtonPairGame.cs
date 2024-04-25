using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPairGame : MonoBehaviour
{
    public RectTransform r;

    private float flipTime = 0.5f;
    public bool faceSide = true;
    public bool block = false;
    public bool Finish = false;
    private int isShriking = -1;
    private bool isFlipping = false;
    public int CardNum = -1;
    public float DistancePerTime = 0;
    float timeCount = 0;
    public Image image;
    public Sprite SpriteBack;
    public Sprite SpriteFront;

    void Start()
    {
        r = GetComponent<RectTransform>();
        DistancePerTime = r.localScale.x / flipTime;
        image = GetComponent<Image>();
        image.sprite = SpriteFront;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShriking * DistancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if(timeCount >= flipTime && isShriking < 0)
            {
                isShriking = 1;
                timeCount = 0;
                if(faceSide == false)
                {
                    faceSide = true;
                    image.sprite = SpriteFront;
                    //Что будет на обратной части
                }
                else
                {
                    faceSide = false;
                    //Что будет на обратной части
                    image.sprite = SpriteBack;
                    Debug.Log(CardNum);
                }
            }
            else if(timeCount >= flipTime && isShriking == 1)
            {
                isFlipping = false;
            }
        }
    }

    public void FlipCard(bool automat)
    {
        if (!isFlipping && !block && !Finish)
        {
            if(automat == false)
            {
                MainScriptPairGame.Compare.Add(this);
            }
            timeCount = 0;
            isFlipping = true;
            isShriking = -1;
        }
    }
}
