using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotOrnament : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        Debug.Log(this.gameObject.name + "υσι");
        if(pointerEventData.pointerDrag != null)
        {
            pointerEventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
