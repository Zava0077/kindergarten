using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI; 

public class GameWords : MonoBehaviour
{
    private bool StatusimageError = false;
    private int RightAnswer;
    public Image image;
    private float time = 0f;
    private bool Status = false;
    public Text text;
    public List<Button> buttons;
    public bool block = false;
    public GameObject MainText;
    public GameObject WinObject;

    private List<Words> words = new List<Words>()
    {
        new Words("«а словом в Е не лезут.", new List<string>(){"карман", "чемодан", "сумка"}),
        new Words("ѕо Е встречают, по уму провожают.", new List<string>(){"одежке", "прическе" , "пальто" }), 
        new Words("¬ хорошем Е и пенек красивый.", new List<string>(){"платье", "настроении", "камзоле"}),
        new Words("ƒва Е Ц пара.", new List<string>(){"сапога", "брата", "солнца"}),
        new Words("Ѕереги Е снову, а честь смолоду.", new List<string>(){"платье", "сарафан", "сапоги"}),
        new Words("ƒруг лучше старый, а Е нова€.", new List<string>(){ "одежда", "сумка", "шапка"}),
        new Words("Ќа воре и Е горит.", new List<string>(){ "шапка", "тулуп", "звезда" }),
        new Words("— миру по Е Ч голому рубаха.", new List<string>(){ "нитке", "рублю", "карману"}),
        new Words(" акова пр€ха, такова на ней Е ", new List<string>(){ "рубаха", "пижама", "сумка"}),
        new Words("Ѕез труда не выловишь и Е из пруда.", new List<string>(){ "рыбку", "звезду", "л€гушку"}),

        new Words(" урочка по зЄрнышку клюЄт, да Е бывает.", new List<string>(){"сыта", "ведро", "желудок"}),
        new Words("¬ здоровом теле Ч здоровый Е.", new List<string>(){"дух", "желудок", "человек" }),
        new Words("—лово не воробей, вылетит Ч не Е.", new List<string>(){ "поймаешь", "догонешь", "возвратишь"}),
        new Words("—тарый друг лучше новых Е.", new List<string>(){ "двух", "знакомых", "книг"}),
        new Words("— глаз долой Ч из Е вон.", new List<string>(){ "сердца", "пам€ти", "головы"}),
        new Words("” семи н€нек дит€ без Е.", new List<string>(){ "глаза", "заботы", "будущего"}),
        new Words("јппетит приходит во врем€ Е.", new List<string>(){ "еды", "обеда", "готовки" }),
        new Words("Ќе рой другому Е, сам в него попадЄшь.", new List<string>(){ "€му", "капкан", "ловушку"}),
        new Words("Ћес руб€т Ч щепки Е.", new List<string>(){ "лет€т", "падают", "разлетаютс€"}),
        new Words("¬ек живи - век Е.", new List<string>(){ "учись", "играй", "отдыхай"}),
    };

    public void ClickButton(int num)
    {
        if (!block)
        {
            block = true;
            if (num == RightAnswer)
            {
                text.text = text.text.Replace("Е", buttons[num].GetComponentInChildren<Text>().text);
                Status = true;
            }
            else
            {
                image.gameObject.SetActive(true);
                StatusimageError = true;
            }
        }
    }

    public void GenerationWords()
    {
        block = false;
        int Random = UnityEngine.Random.Range(0, words.Count-1);
        text.text = words[Random].text;
        RightAnswer = UnityEngine.Random.Range(0, words[Random].answer.Count - 1);
        buttons[RightAnswer].GetComponentInChildren<Text>().text = words[Random].answer[0];
        List<Button> answer = new List<Button>() { buttons[0], buttons[1], buttons[2] };
        answer.Remove(buttons[RightAnswer]);
        int Random1 = UnityEngine.Random.Range(1, words[Random].answer.Count - 1);
        answer[0].GetComponentInChildren<Text>().text = words[Random].answer[Random1];
        if (Random1 == 1)
        {
            answer[1].GetComponentInChildren<Text>().text = words[Random].answer[2];
        }
        else
        {
            answer[1].GetComponentInChildren<Text>().text = words[Random].answer[1];
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GenerationWords();
        image.gameObject.SetActive(false);
        WinObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Status)
        {
            WinObject.SetActive(true);
            time = time + Time.deltaTime;
            if(time > 5f)
            {
                Status = false;
                WinObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
        if (StatusimageError) 
        {
            time = time + Time.deltaTime;
            MainText.SetActive(false);
            if (time > 5f)
            {
                MainText.SetActive(true);
                StatusimageError = false;
                image.gameObject.SetActive(false);
                GenerationWords();
                time = 0f;
            }
        }
    }

    class Words
    {
        public string text;
        public List<string> answer;

        public Words(string txt,List<string> answers)
        {
            text = txt;
            answer = answers;
        }
    }
}
