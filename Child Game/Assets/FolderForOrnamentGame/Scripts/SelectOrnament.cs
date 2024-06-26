using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SelectOrnament : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    RectTransform transform;
    CanvasGroup group;
    public Image image;
    public int CodeOrnament;
    public Vector3 pos;
    public SlotOrnament currentSlot;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        pos = transform.localPosition;
        group = GetComponent<CanvasGroup>();

    }
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        group.alpha = 6f;
        group.blocksRaycasts = false;
        Debug.Log(CodeOrnament);
        if (currentSlot != null)
        {
            currentSlot.ClearCodeSlot();
            currentSlot = null;
        }
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        if(GetComponentInParent<MainScript>().Game.transform.rotation.z == 1)
        {
            transform.anchoredPosition -= pointerEventData.delta / canvas.scaleFactor;
        }
        else
        {
            transform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
        }
        
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }
}
