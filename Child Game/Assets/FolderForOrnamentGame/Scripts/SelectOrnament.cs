using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectOrnament : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    RectTransform transform;
    CanvasGroup group;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        group.alpha = 6f;
        group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }
}
