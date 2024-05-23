using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SlotOrnament : MonoBehaviour, IDropHandler
{
    public int CodeSlot;
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if(pointerEventData.pointerDrag != null)
        {
            AudioSource.Play();
            pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            CodeSlot = pointerEventData.pointerDrag.GetComponent<SelectOrnament>().CodeOrnament;
            Debug.Log(CodeSlot);
        }
    }
}
