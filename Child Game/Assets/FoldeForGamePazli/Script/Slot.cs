using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour, IDropHandler
{
    public int CodeSlot;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag != null)
        {
            pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            CodeSlot = pointerEventData.pointerDrag.GetComponent<Select>().CodePazel;
            Debug.Log(CodeSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

