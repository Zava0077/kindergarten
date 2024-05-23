using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour, IDropHandler
{
    public int CodeSlot { get; set; }
    // Start is called before the first frame update
    void Start()
    {

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
            var select = pointerEventData.pointerDrag.GetComponent<Select>();
            if (select != null)
            {
                pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                CodeSlot = pointerEventData.pointerDrag.GetComponent<Select>().CodePazel;
                select.currentSlot = this;
                Debug.Log(CodeSlot);
            }
        }
    }
}

