using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour, IDropHandler
{
    public int CodeSlot { get; set; }
    public Select select;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClearCodeSlot()
    {
        CodeSlot = 0;
        Debug.Log("CodeSlot סבנמרום");
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag != null)
        {
            select = pointerEventData.pointerDrag.GetComponent<Select>();
            if (select != null)
            {
                pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                CodeSlot = pointerEventData.pointerDrag.GetComponent<Select>().CodePazel;
                select.currentSlot = this;
                audioSource.Play();
                Debug.Log(CodeSlot);
            }
        }
    }
}

