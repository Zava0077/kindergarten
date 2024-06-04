using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotOrnament : MonoBehaviour, IDropHandler
{
    public int CodeSlot;
    AudioSource AudioSource;
    public GameObject Status;
    public SelectOrnament select;
    public bool answer;
    public List<Sprite> Sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ClearCodeSlot()
    {
        CodeSlot = 0;
        Debug.Log("CodeSlot סבנמרום");
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        /*
        if(pointerEventData.pointerDrag != null)
        {
            AudioSource.Play();
            pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            CodeSlot = pointerEventData.pointerDrag.GetComponent<SelectOrnament>().CodeOrnament;
            Debug.Log(CodeSlot);
        }
        */
        if (pointerEventData.pointerDrag != null)
        {
            select = pointerEventData.pointerDrag.GetComponent<SelectOrnament>();
            if (select != null)
            {
                AudioSource.Play();
                pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                CodeSlot = pointerEventData.pointerDrag.GetComponent<SelectOrnament>().CodeOrnament;
                select.currentSlot = this;
                Debug.Log(CodeSlot);
            }
        }
    }

    private void Update()
    {
        if(answer == false)
        {
            Status.gameObject.GetComponent<Image>().sprite = Sprites[0];
        }
        else
        {
            Status.gameObject.GetComponent<Image>().sprite = Sprites[1];
        }
    }
}
