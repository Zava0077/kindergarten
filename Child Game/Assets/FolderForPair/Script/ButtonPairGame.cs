using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPairGame : MonoBehaviour
{
    public RectTransform r;

    private float flipTime = 0.3f;
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
    public Text Name;
    private AudioSource audio;

    private Dictionary<string, string> text = new Dictionary<string, string>()
    {
        { "Russia", "Русский" },
        { "Tatar", "Татар" },
        { "Belorus", "Белорус" },
        { "Ukrain", "Украинец" },
        { "Kirgis", "Киргиз" },
        { "Azerbaijani", "Азербайджанец" },
        { "Kazah", "Казах" },
        { "Burat", "Бурят" },
        { "German", "Немец" },
        { "Arman", "Армянин" },
        { "Tadjick", "Таджик" },
        { "Chuvash", "Чуваш" }
    };

    void Start()
    {
        audio = GetComponent<AudioSource>();
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
                    Name.text = "";
                }
                else
                {
                    faceSide = false;
                    image.sprite = SpriteBack;
                    Debug.Log(CardNum);
                    foreach (var entry in text)
                    {
                        if (SpriteBack.name.Contains(entry.Key))
                        {
                            Name.text = entry.Value;
                        }
                    }
                }
            }
            else if(timeCount >= flipTime && isShriking == 1)
            {
                Vector3 f = r.localScale;
                f.x = 1;
                r.localScale = f;
                isFlipping = false;
            }
        }
    }

    public void FlipCard(bool automat)
    {
        if (!isFlipping && !block && !Finish)
        {
            audio.Play();
            if(automat == false)
            {
                GetComponentInParent<MainScriptPairGame>().Compare.Add(this);
            }
            timeCount = 0;
            isFlipping = true;
            isShriking = -1;
        }
    }
}
